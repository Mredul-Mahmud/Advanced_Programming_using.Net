using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Symptom { get; set; }
        public string Location { get; set; }

    }
}
