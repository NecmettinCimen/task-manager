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
                                      select new WorkDto
                                      {
                                          Id=w.Id,
                                          Title=w.Title,
                                          CreateDate = w.CreateDate,
                                          EventName=e.Name
                                      }).ToListAsync(),
                    EventList = await _baseService.GetList<Event>().ToListAsync()
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
            return View("Index",result);
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
