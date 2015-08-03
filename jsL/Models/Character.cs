using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jsL.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Organization> Organizations { get; set; }
    }

    public class Organization
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}