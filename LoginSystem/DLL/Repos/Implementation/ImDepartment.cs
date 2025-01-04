using DLL.EF;
using DLL.Repos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repos.Implementation
{
    public class ImDepartment : IDepartment
    {
        public Task Add(Department model)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Department>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Department> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Department model)
        {
            throw new NotImplementedException();
        }
    }
}
