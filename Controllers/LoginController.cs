using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManager.Models;
using TaskManager.Services;

namespace TaskManager.Controllers
{
    public class LoginController : Controller
    {
        private readonly IBaseService _baseService;

        public LoginController(IBaseService baseService)
        {
            _baseService = baseService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> IndexAsync(User model)
        {
            var item = await _baseService.GetList<User>()
                .FirstOrDefaultAsync(f => f.Email == model.Email && f.Password == model.Password);
            if (item != null)
            {
                HttpContext.Session.SetInt32("userid", item.Id);
                HttpContext.Session.SetString("username", item.NameSurname);
                Response.Cookies.Append("userid", item.Id.ToString());
                Response.Cookies.Append("username", item.NameSurname);
            }

            return Redirect("/");
        }

        [HttpPost("Logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("userid");
            Response.Cookies.Delete("username");

            HttpContext.Session.Clear();

            return Redirect("/");
        }
    }
}