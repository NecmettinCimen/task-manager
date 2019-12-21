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
            List<Work> list = await _baseService.GetList<Work>().Where(f => FriendlyURL.GetURLFromTitle(f.Title) == work).ToListAsync();
            Work model = list.FirstOrDefault();
            if (model != null)
            {
                Event workevent = _baseService.GetList<Event>().First(f => f.Id == model.EventId);
                List<Work> childList = await _baseService.GetList<Work>().Where(w => w.ParentWorkId == model.Id).ToListAsync();
                
                return View(new ApiResultModel<WorkViewModel>(new WorkViewModel
                {
                    Id=model.Id,
                    CreateDate=model.CreateDate,
                    ChildWorkList=childList,
                    EventName = workevent.Name,
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
            Project project = await _baseService.Get<Project>(model.ProjectId);
            await _baseService.Save(model);
            await _baseService.Save(new WorkHistory() { PrevStatus = model.Status, WorkId = model.Id, ManagerId = model.ManagerId });
            await _baseService.Save(new WorkLabels() { WorkId = model.Id, LabelId = 1 });

            return Redirect("/" + FriendlyURL.GetURLFromTitle(project.Title));
        }


        public async Task<IActionResult> UpdateStatus(Work model)
        {
            Work item = await _baseService.Get<Work>(model.Id);
            Project project = await _baseService.Get<Project>(model.ProjectId);
            item.EventId = model.EventId;

            await _baseService.Save(item);
            await _baseService.Save(new WorkHistory() { PrevStatus = model.Status, WorkId = model.Id, ManagerId = model.ManagerId });

            return Redirect("/" + FriendlyURL.GetURLFromTitle(project.Title));
        }

        public class UpdateLabelsDto
        {
            public int Id { get; set; }
            public int ProjectId { get; set; }
            public string Name { get; set; }
            public int WorkId { get; set; }
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

            return Redirect("/" + FriendlyURL.GetURLFromTitle(project.Title));
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
