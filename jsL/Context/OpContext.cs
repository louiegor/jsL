using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using jsL.Models;

namespace jsL.Context
{
    public class OpContext : DbContext
    {
        public OpContext()
            : base("opDb")
        {
        }

        public DbSet<Character> Characters { get; set; }
        public DbSet<Organization> Organizations { get; set; }
    }
}