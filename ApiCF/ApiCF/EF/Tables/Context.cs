using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ApiCF.EF.Tables
{
    public class Context:DbContext

    {
        public DbSet<Students>Students { get; set; }    
    }
}