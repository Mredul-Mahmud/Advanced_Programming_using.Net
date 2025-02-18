using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class PatientRepo : Repo, IRepo<Patient, int>
    {
        public void Create(Patient p)
        {
            db.Patients.Add(p);
            db.SaveChanges();
        }
        public List<Patient> Get()
        {
            return db.Patients.ToList();
        }
        public Patient Get(int id)
        {
            return db.Patients.Find(id);
        }
        public void Update(Patient p)
        {
            var exobj = Get(p.Id);
            db.Entry(exobj).CurrentValues.SetValues(p);
            db.SaveChanges();

        }
        public void Delete(int id)
        {
            var exobj = Get(id);
            db.Patients.Remove(exobj);
            db.SaveChanges();
        }
    }
}
