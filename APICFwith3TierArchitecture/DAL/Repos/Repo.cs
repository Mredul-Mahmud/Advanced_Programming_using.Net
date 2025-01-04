using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class Repo
    {
        protected APICF3TierContext db;
        public Repo()
        {
            db = new APICF3TierContext();
        }
    }
}
