using DLL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repos.Interfaces
{
    public interface IEmployee
    {
        Task<IEnumerable<Employee>> GetAll();
        Task<Employee>GetById(int id);
        Task Add(Employee model);
        Task Update(Employee model);
        Task Delete (int id);
    }
}
