using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaskManager.Models;
using TaskManager.Services;

namespace TaskManager.Controllers
{
    public class ProjectController : Controller, IBaseController<Project>
    {
        readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public async Task<ActionResult> Index(string project)
        {
            ApiResultModel<Project> model = await _projectService.GetByTitle(project);
            if (model.Success)
                return View(model);
            else
                return Redirect("/");
        }

        public async Task<IActionResult> Delete(int id)
        {
            return Json(await _projectService.Delete(id));
        }

        public async Task<IActionResult> Get(int id)
        {
            return Json(await _projectService.Get(id));
        }

        public async Task<IActionResult> List()
        {
            return Json(await _projectService.GetList());
        }

        public async Task<IActionResult> Save([FromBody]Project model)
        {
            return Json(await _projectService.Save(model));
        }
    }
    public class EventController : Controller, IBaseController<Event>
    {
        readonly IEventService _eventService;
        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        public async Task<IActionResult> Delete(int id)
        {
            return Json(await _eventService.Delete(id));
        }

        public async Task<IActionResult> Get(int id)
        {
            return Json(await _eventService.Get(id));
        }

        public async Task<IActionResult> List()
        {
            return Json(await _eventService.GetList());
        }

        public async Task<IActionResult> Save(Event model)
        {
            return Json(await _eventService.Save(model));
        }
    }
}
