using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TaskManager.Models;
using TaskManager.Services;

namespace TaskManager.Controllers
{
    public class LoginController : Controller
    {
        readonly IBaseService _baseService;
        public LoginController(IBaseService baseService)
        {
            _baseService = baseService;
        }

        [HttpPost]
        public async Task<IActionResult> IndexAsync(User model)
        {
            User item = await _baseService.GetList<User>().FirstOrDefaultAsync(f => f.Email == model.Email && f.Password == model.Password);
            if (item != null)
            {
                HttpContext.Session.SetInt32("userid", item.Id);
                HttpContext.Session.SetString("username", item.NameSurname);
            }

            return Redirect("/");
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return Redirect("/");
        }
    }
}