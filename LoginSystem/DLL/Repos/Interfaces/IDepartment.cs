using DLL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repos.Interfaces
{
    public interface IDepartment
    {
        Task<IEnumerable<Department>> GetAll();
        Task<Department> GetById(int id);
        Task Add(Department model);
        Task Update(Department model);
        Task Delete(int id);
    }
}
