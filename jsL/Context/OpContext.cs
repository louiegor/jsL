using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using jsL.Models;

namespace jsL.Context
{
    public class OpContext : DbContext
    {
        public OpContext()
            : base("Data Source=localhost;Initial Catalog=opDb;Integrated Security=SSPI;")
        {
        }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Stats> Stats { get; set; }
    }
}