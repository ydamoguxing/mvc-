using StudentSystem.IBLL;
using StudentSystem.IDAL;
using StudentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.BLL
{
    public class GradeManager : IGradeManager
    {
        private readonly IGradeService _server;
        public GradeManager(IGradeService server)
        {
            this._server = server;
        }
        public async Task CreateAsync(Grade model, bool saved = true)
        {
           await _server.CreateAsync(model, saved);
        }

        public Task EditAsync(Grade model, bool saved = true)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Grade> GetAll()
        {
            return _server.GetAll();
        }

        public Task<Grade> GetOneByIdAsync(Guid id, bool saved = true)
        {
            throw new NotImplementedException();
        }

        public Task ReoveAsync(Guid id, bool saved = true)
        {
            throw new NotImplementedException();
        }

        public Task ReoveAsync(Grade model, bool saved = true)
        {
            throw new NotImplementedException();
        }

        public Task Save()
        {
            throw new NotImplementedException();
        }
    }
}
