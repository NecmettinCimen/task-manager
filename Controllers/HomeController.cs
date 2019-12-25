using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Models;
using TaskManager.Services;

namespace TaskManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBaseService _baseService;

        public HomeController(ILogger<HomeController> logger, IBaseService baseService)
        {
            _logger = logger;
            _baseService = baseService;
        }

        public async Task<IActionResult> Index()
        {
            List<Project> data = await _baseService.GetList<Project>().ToListAsync();
            var result = data.Select(s => new HomeIndexViewModel
            {
                Id = s.Id,
                Url = s.Url,
                Title = s.Title,
                WorkProgres = _baseService.GetList<Work>().Count(w => w.ProjectId == s.Id) > 0 ?
                      Convert.ToInt32((Convert.ToDouble(_baseService.GetList<Work>().Count(w => w.ProjectId == s.Id && w.EventId != 1)) /
                     Convert.ToDouble(_baseService.GetList<Work>().Count(w => w.ProjectId == s.Id))) * 100): 0,
            }).ToList();
            return View(new ApiResultModel<List<HomeIndexViewModel>>(result));
        }

    }
}
