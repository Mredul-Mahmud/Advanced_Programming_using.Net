using DLL.EF;
using DLL.Repos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repos.Implementation
{
    public class ImDesignation : IDesignation
    {
        public Task Add(Designation model)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Designation>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Designation> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Designation model)
        {
            throw new NotImplementedException();
        }
    }
}
