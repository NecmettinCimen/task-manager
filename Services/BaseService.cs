using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using TaskManager.Models;

namespace TaskManager.Services
{
    public interface IBaseService
    {
        IQueryable<T> GetList<T>() where T : BaseEntity;
        Task<T> Get<T>(int id) where T : BaseEntity;
        Task<int> Save<T>(T model) where T : BaseEntity;
        Task<bool> Delete<T>(int id) where T : BaseEntity;
        Task<bool> Archive<T>(int id) where T : BaseEntity;
    }

    public class BaseService : IBaseService
    {
        private readonly MainContext _mainContext;

        public BaseService(MainContext mainContext)
        {
            _mainContext = mainContext;
        }

        public IQueryable<T> GetList<T>() where T : BaseEntity
        {
            IQueryable<T> list = _mainContext.Set<T>().Where(w => w.Status != 0 && w.Status != 2).OrderByDescending(o => o.Id);
            var user = AppHttpContext.Current.Session.GetInt32("userid");
            if (user.HasValue)
                list = list.Where(w => w.CreatorId == user.Value || w.Public);
            else
                list = list.Where(w => w.Public);

            return list;
        }

        public async Task<T> Get<T>(int id) where T : BaseEntity
        {
            return await _mainContext.Set<T>().FindAsync(id);
        }

        public async Task<int> Save<T>(T model) where T : BaseEntity
        {
            var user = AppHttpContext.Current.Session.GetInt32("userid");
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
            var model = await Get<T>(id);
            model.CreateDate = DateTime.Now;
            model.Status = 0;

            _mainContext.Set<T>().Update(model);

            await _mainContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Archive<T>(int id) where T : BaseEntity
        {
            var model = await Get<T>(id);
            model.Status = 2;

            _mainContext.Set<T>().Update(model);

            await _mainContext.SaveChangesAsync();

            return true;
        }
    }
}