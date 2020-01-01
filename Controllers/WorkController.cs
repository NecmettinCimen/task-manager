using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Models;
using TaskManager.Services;

namespace TaskManager.Controllers
{
    public class WorkController : Controller, IBaseController<Work>
    {
        readonly IBaseService _baseService;
        public WorkController(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ActionResult> Index(string work)
        {
            Work model = _baseService.GetList<Work>().FirstOrDefault(f => f.Url == work);
            if (model != null)
            {
                Event workevent = await _baseService.Get<Event>(model.EventId);
                Project project = await _baseService.Get<Project>(model.ProjectId);

                return View(new ApiResultModel<WorkViewModel>(new WorkViewModel
                {
                    Id = model.Id,
                    Title = model.Title,
                    Url = model.Url,
                    Explanation = model.Explanation,
                    CreateDate = model.CreateDate,
                    ProjectName = project.Title,
                    ProjectId = model.ProjectId,
                    ProjectManagerId = project.ManagerId,
                    ProjectUrl = project.Url,
                    ChildWorkList = await (from w in _baseService.GetList<Work>()
                                           where w.ParentWorkId == model.Id
                                           join e in _baseService.GetList<Event>() on w.EventId equals e.Id
                                           orderby w.EventId
                                           select new WorkDto
                                           {
                                               Id = w.Id,
                                               Title = w.Title,
                                               Url = w.Url,
                                               CreateDate = w.CreateDate,
                                               EventName = e.Name,
                                               ManagerId = w.ManagerId,
                                               ProjectId = w.ProjectId,
                                               Labels = _baseService.GetList<WorkLabels>().Where(wl => wl.WorkId == w.Id).Select(s => s.LabelId).ToList(),
                                               FirstLabelName = (from wl in _baseService.GetList<WorkLabels>().Where(f => f.WorkId == w.Id)
                                                                 join l in _baseService.GetList<Label>() on wl.LabelId equals l.Id
                                                                 select l.Name).First()
                                           }).ToListAsync(),
                    EventName = workevent.Name,
                    EventList = await _baseService.GetList<Event>().ToListAsync(),
                    LabelList = await _baseService.GetList<Label>().ToListAsync()
                }));
            }
            else
                return Redirect("/");
        }

        public async Task<IActionResult> Delete(int id)
        {
            ApiResultModel<bool> result;

            try
            {
                result = new ApiResultModel<bool>(await _baseService.Delete<Work>(id));
            }
            catch (System.Exception ex)
            {

                result = new ApiResultModel<bool>(false, ex.Message);
            }
            return Json(result);
        }


        public async Task<IActionResult> Save(Work model)
        {
            model.Url = FriendlyURL.GetURLFromTitle(model.Title);
            await _baseService.Save(model);
            await _baseService.Save(new WorkHistory() { PrevStatus = model.Status, WorkId = model.Id, ManagerId = model.ManagerId });
            await _baseService.Save(new WorkLabels() { WorkId = model.Id, LabelId = 1 });

            if (model.ParentWorkId.HasValue)
            {
                Work work = await _baseService.Get<Work>(model.ParentWorkId.Value);
                return Redirect($"/work/{work.Url}");
            }
            else
            {
                Project project = await _baseService.Get<Project>(model.ProjectId);
                return Redirect($"/{project.Url}");
            }

        }

        public async Task<IActionResult> Update(Work model)
        {
            Work item = await _baseService.Get<Work>(model.Id);
            item.Title = model.Title;
            item.Url = FriendlyURL.GetURLFromTitle(model.Title);
            item.Explanation = model.Explanation;
            await _baseService.Save(item);

            return Redirect($"/work/{item.Url}");
        }


        public async Task<IActionResult> UpdateStatus(Work model)
        {
            Work item = await _baseService.Get<Work>(model.Id);
            item.EventId = model.EventId;

            await _baseService.Save(item);
            await _baseService.Save(new WorkHistory() { PrevStatus = model.Status, WorkId = model.Id, ManagerId = model.ManagerId });

            if (model.ParentWorkId.HasValue)
            {
                return Redirect($"/work/{model.Url}");
            }
            else
            {
                Project project = await _baseService.Get<Project>(model.ProjectId);
                return Redirect($"/{project.Url}");
            }
        }

        public async Task<IActionResult> Remove(int id)
        {
            Work item = await _baseService.Get<Work>(id);

            await _baseService.Delete<Work>(id);


            if (item.ParentWorkId.HasValue)
            {
                Work work = await _baseService.Get<Work>(item.ParentWorkId.Value);
                return Redirect($"/work/{work.Url}");
            }
            else
            {
                Project project = await _baseService.Get<Project>(item.ProjectId);
                return Redirect($"/{project.Url}");
            }
        }

        public async Task<IActionResult> UpdateLabels(UpdateLabelsDto model)
        {
            Project project = await _baseService.Get<Project>(model.ProjectId);
            Label item = new Label() { Id = model.Id, Name = model.Name };

            if (model.Id == 0)
            {
                await _baseService.Save(item);
            }
            else
            {
                WorkLabels workLabels = await _baseService.GetList<WorkLabels>().FirstOrDefaultAsync(f => f.LabelId == model.Id && f.WorkId == model.WorkId);
                if (workLabels != null)
                {
                    await _baseService.Delete<WorkLabels>(workLabels.Id);
                }
                else
                {
                    await _baseService.Save(new WorkLabels { LabelId = item.Id, WorkId = model.WorkId });
                }
            }

            return Redirect($"/{project.Url}");
        }

        public Task<IActionResult> Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IActionResult> List()
        {
            throw new System.NotImplementedException();
        }
    }

}
