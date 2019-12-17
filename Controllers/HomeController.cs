using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
            return View(await _baseService.GetList<Project>().ToListAsync());
        }

    }
}
