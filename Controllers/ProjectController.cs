using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Models;
using TaskManager.Services;

namespace TaskManager.Controllers
{
    public class ProjectController : Controller, IBaseController<Project>
    {
        readonly IBaseService _baseService;
        public ProjectController(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ActionResult> Index(string project)
        {
            List<Project> list = await _baseService.GetList<Project>().ToListAsync();
            Project model = list.FirstOrDefault(f => FriendlyURL.GetURLFromTitle(f.Title) == project);
            if (model != null)
            {
                ProjectViewModel result = new ProjectViewModel
                {
                    Project = model,
                    WorkList = await (from w in _baseService.GetList<Work>()
                                      where w.ProjectId == model.Id 
                                      join e in _baseService.GetList<Event>() on w.EventId equals e.Id
                                      orderby w.EventId
                                      select new WorkDto
                                      {
                                          Id=w.Id,
                                          Title=w.Title,
                                          CreateDate = w.CreateDate,
                                          EventName=e.Name,
                                          ManagerId=w.ManagerId,
                                          ProjectId=w.ProjectId,
                                          Labels=_baseService.GetList<WorkLabels>().Where(wl=>wl.WorkId==w.Id).Select(s=>s.LabelId).ToList(),
                                          FirstLabelName = (from wl in _baseService.GetList<WorkLabels>().Where(f => f.WorkId == w.Id)
                                                            join l in _baseService.GetList<Label>() on wl.LabelId equals l.Id
                                                            select l.Name).First()
                                      }).ToListAsync(),
                    EventList = await _baseService.GetList<Event>().ToListAsync(),
                    LabelList = await _baseService.GetList<Label>().ToListAsync()
                };

                return View(new ApiResultModel<ProjectViewModel>(result));
            }
            else
                return Redirect("/");
        }

        public async Task<IActionResult> Delete(int id)
        {
            ApiResultModel<bool> result;

            try
            {
                result = new ApiResultModel<bool>(await _baseService.Delete<Project>(id));
            }
            catch (System.Exception ex)
            {

                result = new ApiResultModel<bool>(false, ex.Message);
            }
            return Json(result);
        }


        public async Task<IActionResult> Save(Project model)
        {
            ApiResultModel<List<Project>> result;

            try
            {
                await _baseService.Save(model);
                result = new ApiResultModel<List<Project>>(await _baseService.GetList<Project>().ToListAsync());
            }
            catch (System.Exception ex)
            {

                result = new ApiResultModel<List<Project>>(null, ex.Message);
            }
            return View("~/Views/Home/Index.cshtml",result);
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
