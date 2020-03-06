using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManager.Models;
using TaskManager.Services;

namespace TaskManager.Controllers
{
    public class ProjectController : Controller,
        IBaseController<Project>
    {
        private readonly IBaseService _baseService;

        public ProjectController(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<IActionResult> Delete(int id)
        {
            ApiResultModel<bool> result;
            try
            {
                result = new ApiResultModel<bool>(await _baseService.Delete<Project>(id));
            }
            catch (Exception ex)
            {
                result = new ApiResultModel<bool>(false,
                    ex.Message);
            }

            return Json(result);
        }

        public async Task<IActionResult> Save(Project model)
        {
            var user = HttpContext.Session.GetInt32("userid");
            model.ManagerId = user ?? 1;
            model.Url = FriendlyURL.GetURLFromTitle(model.Title);
            await _baseService.Save(model);
            return Redirect($"/{model.Url}");
        }

        public async Task<IActionResult> UpdateDisplayOrder(string id)
        {
            int[] ids = id.Split(",").Select(s=>int.Parse(s)).ToArray();
            var projects = await _baseService.GetList<Project>().ToListAsync();
            for (int i = 0; i < ids.Length; i++)
            {
                var temp = projects.Find(f => f.Id == ids[i]);
                temp.DisplayOrder = i + 1;
                await _baseService.Save(temp);
            }
            return Json(true);
        }
        public Task<IActionResult> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> List()
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult> Index(string project,
            string key)
        {
            var model = _baseService.GetList<Project>()
                .FirstOrDefault(f => f.Url == project);
            if (model != null)
            {
                var result = new ProjectViewModel
                {
                    Project = model,
                    WorkList = await (from w in _baseService.GetList<Work>()
                        where w.ProjectId == model.Id && !w.ParentWorkId.HasValue
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
                            Labels =
                                _baseService.GetList<WorkLabels>()
                                    .Where(wl => wl.WorkId == w.Id)
                                    .Select(s => s.LabelId)
                                    .ToList(),
                            FirstLabelName =
                                (from wl in _baseService.GetList<WorkLabels>()
                                        .Where(f => f.WorkId == w.Id)
                                    join l in _baseService.GetList<Label>() on wl.LabelId equals l.Id
                                    select l.Name).First(),
                            WorkProgres = _baseService.GetList<Work>()
                                              .Count(w => w.ParentWorkId == w.Id) >
                                          0
                                ? Convert.ToInt32(
                                    Convert.ToDouble(_baseService.GetList<Work>()
                                        .Count(w => w.ParentWorkId == w.Id && w.EventId != 1)) /
                                    Convert.ToDouble(_baseService.GetList<Work>()
                                        .Count(w => w.ParentWorkId == w.Id)) *
                                    100)
                                : w.EventId == 1
                                    ? 0
                                    : 100
                        }).ToListAsync(),
                    EventList = await _baseService.GetList<Event>()
                        .ToListAsync(),
                    LabelList = await _baseService.GetList<Label>()
                        .ToListAsync()
                };
                return View(new ApiResultModel<ProjectViewModel>(result));
            }

            return Redirect("/");
        }

        public async Task<IActionResult> Update(Project model)
        {
            var item = await _baseService.Get<Project>(model.Id);
            item.Title = model.Title;
            item.Explanation = model.Explanation;
            item.Url = FriendlyURL.GetURLFromTitle(item.Title);
            await _baseService.Save(item);
            return Redirect($"/{item.Url}");
        }

        public async Task<IActionResult> Share(Project model)
        {
            var item = await _baseService.Get<Project>(model.Id);
            if (string.IsNullOrEmpty((item.ShareKey)))
            {
                item.ShareKey = RandomString.Generate(10);
                await _baseService.Save(item);
            }
            return Redirect($"/{item.Url}?sharekey={item.ShareKey}");
        }

        public async Task<IActionResult> Remove(int id)
        {
            await _baseService.Delete<Project>(id);
            return Redirect("/");
        }

        public async Task<IActionResult> Archive(int id)
        {
            await _baseService.Archive<Project>(id);
            return Redirect("/");
        }
        public async Task<IActionResult> UpdatePublic(int id)
        {
            var project = await _baseService.Get<Project>(id);
            var user = HttpContext.Session.GetInt32("userid");
            if (user.HasValue && project.CreatorId == user.Value)
            {
                project.Public = !project.Public;
                await _baseService.Save(project);
            }

            return Json(true);
        }
    }
}