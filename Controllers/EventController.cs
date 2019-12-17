using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManager.Models;
using TaskManager.Services;

namespace TaskManager.Controllers
{
    public class EventController : Controller, IBaseController<Event>
    {
        readonly IBaseService _baseService;
        public EventController(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ActionResult> Index()
        {
            ApiResultModel<List<Event>> result = new ApiResultModel<List<Event>>(await _baseService.GetList<Event>().ToListAsync());
            return View(result);
        }

        public Task<IActionResult> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IActionResult> Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IActionResult> List()
        {
            ApiResultModel<List<Event>> result;

            try
            {
                result = new ApiResultModel<List<Event>>(await _baseService.GetList<Event>().ToListAsync());
            }
            catch (System.Exception ex)
            {

                result = new ApiResultModel<List<Event>>(null, ex.Message);
            }
            return Json(result);
        }

        public async Task<IActionResult> Save(Event model)
        {
            ApiResultModel<List<Event>> result;

            try
            {
                await _baseService.Save(model);
                result = new ApiResultModel<List<Event>>(await _baseService.GetList<Event>().ToListAsync());
            }
            catch (System.Exception ex)
            {

                result = new ApiResultModel<List<Event>>(new List<Event>(), ex.Message);
            }
            return View("Index", result);
        }
    }
}