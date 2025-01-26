using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApiCF.EF.Tables
{
    public class Students
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public float Cgpa{ get; set; }
    }
}