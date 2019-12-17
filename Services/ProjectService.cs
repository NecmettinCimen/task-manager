using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Models;

namespace TaskManager.Services
{
    public interface IProjectService
    {
        Task<ApiResultModel<List<Project>>> GetList();
        Task<ApiResultModel<Project>> Get(int id);
        Task<ApiResultModel<Project>> GetByTitle(string id);
        Task<ApiResultModel<int>> Save(Project model);
        Task<ApiResultModel<bool>> Delete(int id);
    }
    public class ProjectService : IProjectService
    {
        readonly IBaseService _baseService;
        public ProjectService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public async Task<ApiResultModel<bool>> Delete(int id)
        {
            try
            {
                return new ApiResultModel<bool>(await _baseService.Delete<Project>(id));
            }
            catch (System.Exception ex)
            {

                return new ApiResultModel<bool>(error:ex.Message);
            }
        }

        public async Task<ApiResultModel<Project>> Get(int id)
        {
            try
            {
                return new ApiResultModel<Project>(await _baseService.Get<Project>(id));
            }
            catch (System.Exception ex)
            {

                return new ApiResultModel<Project>(error: ex.Message);
            }
        }

        public async Task<ApiResultModel<Project>> GetByTitle(string id)
        {
            try
            {
                List<Project> list = await _baseService.GetList<Project>().ToListAsync();
                Project data = list.FirstOrDefault(f => FriendlyURL.GetURLFromTitle(f.Title) == id);
                return new ApiResultModel<Project>(data);
            }
            catch (System.Exception ex)
            {
                return new ApiResultModel<Project>(error: ex.Message);
            }
        }

        public async Task<ApiResultModel<List<Project>>> GetList()
        {
            try
            {
                return new ApiResultModel<List<Project>>(await _baseService.GetList<Project>().ToListAsync());
            }
            catch (System.Exception ex)
            {
                return new ApiResultModel<List<Project>>(error: ex.Message);
            }
        }

        public async Task<ApiResultModel<int>> Save(Project model)
        {
            try
            {
                return new ApiResultModel<int>(await _baseService.Save(model));
            }
            catch (System.Exception ex)
            {

                return new ApiResultModel<int>(error: ex.Message);
            }
        }
    }
}
