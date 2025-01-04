using DLL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repos.Interfaces
{
    public interface IDesignation
    {
        Task<IEnumerable<Designation>> GetAll();
        Task<Designation> GetById(int id);
        Task Add(Designation model);
        Task Update(Designation model);
        Task Delete(int id);
    }
}
