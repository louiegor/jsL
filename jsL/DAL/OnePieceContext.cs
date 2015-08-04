using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using jsL.Models;

namespace jsL.DAL
{
    public class OnePieceContext:DbContext
    {
        public OnePieceContext() : base("OnePieceContext")
        {
        }

        public DbSet<Character> Characters { get; set; }
        public DbSet<Organization> Organizations { get; set; }

    }
}