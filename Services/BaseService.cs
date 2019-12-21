using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Models;
namespace TaskManager.Services
{
    public interface IBaseService
    {
        IQueryable<T> GetList<T>() where T : BaseEntity;
        Task<T> Get<T>(int id) where T : BaseEntity;
        Task<int> Save<T>(T model) where T : BaseEntity;
        Task<bool> Delete<T>(int id) where T : BaseEntity;
    }

    public class BaseService : IBaseService
    {
        readonly MainContext _mainContext;
        public BaseService(MainContext mainContext)
        {
            _mainContext = mainContext;
        }

        public IQueryable<T> GetList<T>() where T : BaseEntity
        {
            IQueryable<T> list = _mainContext.Set<T>().Where(w => w.Status != 0).OrderByDescending(o => o.Id);
            int? user = AppHttpContext.Current.Session.GetInt32("userid");
            if (user.HasValue)
            {
                list = list.Where(w => w.CreatorId == user.Value || w.Public == true);
            }
            else
            {
                list = list.Where(w => w.Public == true);
            }

            return list;
        }
        public async Task<T> Get<T>(int id) where T : BaseEntity
        {
            return await _mainContext.Set<T>().Where(w => w.Status != 0).FirstAsync(f => f.Id == id);
        }
        public async Task<int> Save<T>(T model) where T : BaseEntity
        {
            int? user = AppHttpContext.Current.Session.GetInt32("userid");
            if (user.HasValue)
                model.CreatorId = user.Value;

            if (model.Id == 0)
                await _mainContext.Set<T>().AddAsync(model);
            else
                _mainContext.Set<T>().Update(model);

            await _mainContext.SaveChangesAsync();

            return model.Id;
        }
        public async Task<bool> Delete<T>(int id) where T : BaseEntity
        {

            T model = await Get<T>(id);
            model.Status = 0;

            _mainContext.Set<T>().Update(model);

            await _mainContext.SaveChangesAsync();

            return true;
        }
    }
}