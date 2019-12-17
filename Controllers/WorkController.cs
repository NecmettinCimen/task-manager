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

        public async Task<ActionResult> Index(string Work)
        {
            return View();
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
            ApiResultModel<int> result;

            try
            {
                await _baseService.Save(model);
                await _baseService.Save(new WorkHistory() { PrevStatus = model.Status, WorkId = model.Id, ManagerId = model.ManagerId });
                
                result = new ApiResultModel<int>(model.Id);

            }
            catch (System.Exception ex)
            {

                result = new ApiResultModel<int>(0, ex.Message);
            }
            return Json(result);
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
