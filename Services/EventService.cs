using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManager.Models;

namespace TaskManager.Services
{
    public interface IEventService
    {
        Task<ApiResultModel<List<Event>>> GetList();
        Task<ApiResultModel> Get(int id);
        Task<ApiResultModel> Save(Event model);
        Task<ApiResultModel> Delete(int id);
    }
    public class EventService : IEventService
    {
        readonly IBaseService _baseService;
        public EventService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public async Task<ApiResultModel<List<Event>>>> Delete(int id)
        {
            try
            {
                return new ApiResultModel(await _baseService.Delete<Event>(id));
            }
            catch (System.Exception ex)
            {

                return new ApiResultModel(error: ex.Message);
            }
        }

        public async Task<ApiResultModel> Get(int id)
        {
            try
            {
                return new ApiResultModel(await _baseService.Get<Event>(id));
            }
            catch (System.Exception ex)
            {

                return new ApiResultModel(error: ex.Message);
            }
        }

        public async Task<ApiResultModel> GetList()
        {
            try
            {
                return new ApiResultModel(await _baseService.GetList<Event>().ToListAsync());
            }
            catch (System.Exception ex)
            {

                return new ApiResultModel(error: ex.Message);
            }
        }

        public async Task<ApiResultModel> Save(Event model)
        {
            try
            {
                return new ApiResultModel(await _baseService.Save(model));
            }
            catch (System.Exception ex)
            {

                return new ApiResultModel(error: ex.Message);
            }
        }
    }
}
