using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepo<CLASS, ID>
    {
        void Create(CLASS p);
        CLASS Get(ID id);
        List<CLASS> Get();
        void Delete(ID id);
        void Update(CLASS p);
    }
}
