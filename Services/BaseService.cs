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
            return _mainContext.Set<T>().Where(w => w.Status != 0);
        }
        public async Task<T> Get<T>(int id) where T : BaseEntity
        {
            return await _mainContext.Set<T>().Where(w => w.Status != 0).FirstAsync(f => f.Id == id);
        }
        public async Task<int> Save<T>(T model) where T : BaseEntity
        {
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