using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class APICF3TierContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<MedicalService> MedicalService { get; set; }
    }
}
