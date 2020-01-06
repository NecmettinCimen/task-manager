using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TaskManager.Models;
using TaskManager.Services;

namespace TaskManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBaseService _baseService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IBaseService baseService)
        {
            _logger = logger;
            _baseService = baseService;
        }

        public async Task<IActionResult> Index()
        {
            var user = AppHttpContext.Current.Session.GetInt32("userid");
            var userid = Request.Cookies["userid"] == null ? 0 : int.Parse(Request.Cookies["userid"]);
            if (!user.HasValue && userid != 0)
            {
                HttpContext.Session.SetInt32("userid", userid);
                HttpContext.Session.SetString("username", Request.Cookies["username"]);
            }

            var projectList = await _baseService.GetList<Project>().Select(s => new ProjectListDto
            {
                Id = s.Id,
                Url = s.Url,
                Title = s.Title,
                WorkProgres = _baseService.GetList<Work>().Count(w => w.ProjectId == s.Id) > 0
                    ? Convert.ToInt32(
                        Convert.ToDouble(_baseService.GetList<Work>()
                            .Count(w => w.ProjectId == s.Id && w.EventId != 1)) /
                        Convert.ToDouble(_baseService.GetList<Work>().Count(w => w.ProjectId == s.Id)) * 100)
                    : 0
            }).ToListAsync();

            var workList = await (from w in _baseService.GetList<Work>()
                where !w.ParentWorkId.HasValue
                join s in _baseService.GetList<Project>() on w.ProjectId equals s.Id
                join e in _baseService.GetList<Event>() on w.EventId equals e.Id
                where e.Id == 1
                orderby w.Id
                orderby s.Id
                select new WorkListDto
                {
                    Id = w.Id,
                    Title = w.Title,
                    Url = w.Url,
                    Project = s.Title,
                    Event = e.Name,
                    WorkProgres = _baseService.GetList<Work>().Count(w => w.ParentWorkId == w.Id) > 0
                        ? Convert.ToInt32(Convert.ToDouble(_baseService.GetList<Work>()
                                              .Count(w => w.ParentWorkId == w.Id && w.EventId != 1)) /
                                          Convert.ToDouble(_baseService.GetList<Work>()
                                              .Count(w => w.ParentWorkId == w.Id)) * 100)
                        : 0
                }).ToListAsync();
            return View(new ApiResultModel<HomeIndexViewModel>(new HomeIndexViewModel
                {ProjectList = projectList, WorkList = workList}));
        }
    }
}