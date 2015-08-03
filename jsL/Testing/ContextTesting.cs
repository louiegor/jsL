using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUnit.Framework;
using jsL.Context;
using jsL.Models;

namespace jsL.Testing
{
    [TestFixture]
    public class ContextTesting
    {
        [Test]
        public void Test1()
        {
            using (var db = new OpContext())
            {
                var org = new Organization {Name = "Straw Hat Pirate"};
                var orgList = new List<Organization> {org};
                var character = new Character {Name = "Luffy", Organizations = orgList};
                db.Organizations.Add(org);
                db.Characters.Add(character);
                db.SaveChanges();
            }
        }
        [Test]
        public void Test2()
        {
            using (var db= new OpContext())
            {
                var charas = db.Characters.Where(x => x.Name == "Luffy").ToList();
                Assert.AreEqual(charas.First().Name, "Luffy");
            }
        }
    }
}