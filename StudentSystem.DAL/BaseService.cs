using StudentSystem.IDAL;
using StudentSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.DAL
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity,new()
    {
        private readonly StudentSystemContext _db;
        public BaseService()
        {
            this._db = new StudentSystemContext();
        }
        public async Task CreateAsync(T model, bool saved = true)
        {
            _db.Set<T>().Add(model);
            if (saved)
               await Save();
        }

        public async Task EditAsync(T model, bool saved = true)
        {
            _db.Entry(model).State = EntityState.Modified;
            if (saved)
                await Save();
        }

        public IQueryable<T> GetAll()
        {
            return _db.Set<T>().Where(m => !m.IsMoved).AsNoTracking();
        }

        public  Task<T> GetOneByIdAsync(Guid id, bool saved = true)
        {
            throw new NotImplementedException();
        }

        public Task ReoveAsync(Guid id, bool saved = true)
        {
            throw new NotImplementedException();
        }

        public Task ReoveAsync(T model, bool saved = true)
        {
            throw new NotImplementedException();
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }
    }
}
