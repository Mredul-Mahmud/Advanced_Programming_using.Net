using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class MedicalServiceRepo : Repo
    {
        public void Create(MedicalService m)
        {
            db.MedicalService.Add(m);
            db.SaveChanges();
        }
        public List<MedicalService> Get()
        {
            return db.MedicalService.ToList();
        }
        public MedicalService Get(int id)
        {
            return db.MedicalService.Find(id);
        }
        public void Update(MedicalService m)
        {
            var exobj = Get(m.Id);
            db.Entry(exobj).CurrentValues.SetValues(m);
            db.SaveChanges();   

        }
        public void Delete(int id)
        {
            var exobj = Get(id);
            db.MedicalService.Remove(exobj);
            db.SaveChanges();
        }

    }
}
