using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManager.Models;
using TaskManager.Services;

namespace TaskManager.Controllers
{
    public class WorkController : Controller, IBaseController<Work>
    {
        private readonly IBaseService _baseService;

        public WorkController(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<IActionResult> Delete(int id)
        {
            ApiResultModel<bool> result;

            try
            {
                result = new ApiResultModel<bool>(await _baseService.Delete<Work>(id));
            }
            catch (Exception ex)
            {
                result = new ApiResultModel<bool>(false, ex.Message);
            }

            return Json(result);
        }


        public async Task<IActionResult> Save(Work model)
        {
            model.Url = FriendlyURL.GetURLFromTitle(model.Title);
            await _baseService.Save(model);
            await _baseService.Save(new WorkHistory
                {PrevStatus = model.Status, WorkId = model.Id, ManagerId = model.ManagerId});
            await _baseService.Save(new WorkLabels {WorkId = model.Id, LabelId = 1});
            if (model.ParentWorkId.HasValue)
            {
                var work = await _baseService.Get<Work>(model.ParentWorkId.Value);
                await TelegramBot.SendAsync(
                    $"Yeni bir alt iş oluşturuldu  {model.Id} {model.Title}  Üst İş : {work.Title}");
                return Redirect($"/work/{work.Url}");
            }

            var project = await _baseService.Get<Project>(model.ProjectId);
            await TelegramBot.SendAsync($"Yeni bir iş oluşturuldu {model.Id} {model.Title}  Proje : {project.Title}");
            return Redirect($"/{project.Url}");
        }

        public Task<IActionResult> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> List()
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult> Index(string work)
        {
            var model = _baseService.GetList<Work>().FirstOrDefault(f => f.Url == work);
            if (model != null)
            {
                var workevent = await _baseService.Get<Event>(model.EventId);
                var project = await _baseService.Get<Project>(model.ProjectId);

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
                            Labels = _baseService.GetList<WorkLabels>().Where(wl => wl.WorkId == w.Id)
                                .Select(s => s.LabelId).ToList(),
                            FirstLabelName = (from wl in _baseService.GetList<WorkLabels>().Where(f => f.WorkId == w.Id)
                                join l in _baseService.GetList<Label>() on wl.LabelId equals l.Id
                                select l.Name).First()
                        }).ToListAsync(),
                    EventName = workevent.Name,
                    EventList = await _baseService.GetList<Event>().ToListAsync(),
                    LabelList = await _baseService.GetList<Label>().ToListAsync()
                }));
            }

            return Redirect("/");
        }

        public async Task<IActionResult> Update(Work model)
        {
            var item = await _baseService.Get<Work>(model.Id);
            item.Title = model.Title;
            item.Url = FriendlyURL.GetURLFromTitle(model.Title);
            item.Explanation = model.Explanation;
            await _baseService.Save(item);
            await TelegramBot.SendAsync($"Bir iş güncellendi  {model.Id} {item.Title}");

            return Redirect($"/work/{item.Url}");
        }


        public async Task<IActionResult> UpdateStatus(Work model)
        {
            var item = await _baseService.Get<Work>(model.Id);
            item.EventId = model.EventId;

            await _baseService.Save(item);
            await _baseService.Save(new WorkHistory
                {PrevStatus = model.Status, WorkId = model.Id, ManagerId = model.ManagerId});

            var dbevent = await _baseService.GetList<Event>().FirstAsync(f => f.Id == item.EventId);
            await TelegramBot.SendAsync($"Bir işin durumu güncellendi  {model.Id} {item.Title}  {dbevent.Name}");

            if (model.ParentWorkId.HasValue) return Redirect($"/work/{model.Url}");

            var project = await _baseService.Get<Project>(model.ProjectId);
            return Redirect($"/{project.Url}");
        }

        public async Task<IActionResult> Remove(int id)
        {
            var item = await _baseService.Get<Work>(id);

            await _baseService.Delete<Work>(id);


            if (item.ParentWorkId.HasValue)
            {
                var work = await _baseService.Get<Work>(item.ParentWorkId.Value);
                return Redirect($"/work/{work.Url}");
            }

            var project = await _baseService.Get<Project>(item.ProjectId);
            return Redirect($"/{project.Url}");
        }

        public async Task<IActionResult> UpdateLabels(UpdateLabelsDto model)
        {
            var project = await _baseService.Get<Project>(model.ProjectId);
            var item = new Label {Id = model.Id, Name = model.Name};

            if (model.Id == 0)
            {
                await _baseService.Save(item);
            }
            else
            {
                var workLabels = await _baseService.GetList<WorkLabels>()
                    .FirstOrDefaultAsync(f => f.LabelId == model.Id && f.WorkId == model.WorkId);
                if (workLabels != null)
                    await _baseService.Delete<WorkLabels>(workLabels.Id);
                else
                    await _baseService.Save(new WorkLabels {LabelId = item.Id, WorkId = model.WorkId});
            }

            return Redirect($"/{project.Url}");
        }
    }
}