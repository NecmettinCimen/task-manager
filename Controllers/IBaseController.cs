using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    public interface IBaseController<T> where T : BaseEntity
    {
        Task<IActionResult> List();
        Task<IActionResult> Get(int id);
        Task<IActionResult> Save(T model);
        Task<IActionResult> Delete(int id);
    }
}