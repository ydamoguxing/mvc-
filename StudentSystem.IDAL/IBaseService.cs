using StudentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.IDAL
{
   public interface IBaseService<T> where T:BaseEntity
    {
        Task CreateAsync(T model, bool saved = true);
        Task EditAsync(T model, bool saved = true);
        Task ReoveAsync(Guid id, bool saved = true);
        Task ReoveAsync(T model, bool saved = true);
        Task Save();
        Task<T> GetOneByIdAsync(Guid id, bool saved = true);
        IQueryable<T> GetAll();
    }
}
