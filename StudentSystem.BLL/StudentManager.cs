using StudentSystem.IBLL;
using StudentSystem.IDAL;
using StudentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.BLL
{
    public class StudentManager : IStudentManager
    {
        private readonly IStudentService _server;
        public StudentManager(IStudentService service)
        {
            this._server = service;
        }
        public async Task CreateAsync(Student model, bool saved = true)
        {
            await _server.CreateAsync(model, saved);
        }

        public Task EditAsync(Student model, bool saved = true)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Student> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Student> GetOneByIdAsync(Guid id, bool saved = true)
        {
            throw new NotImplementedException();
        }

        public Task ReoveAsync(Guid id, bool saved = true)
        {
            throw new NotImplementedException();
        }

        public Task ReoveAsync(Student model, bool saved = true)
        {
            throw new NotImplementedException();
        }

        public Task Save()
        {
            throw new NotImplementedException();
        }
    }
}
