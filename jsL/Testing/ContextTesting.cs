using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUnit.Framework;
using jsL.Context;
using jsL.Models;
using jsL.Services;

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
                var org = db.Organizations.Single(x => x.Name == "Straw Hat Pirate");
                var character = new Character
                    {
                        Name = "Nami",
                        Organization = org,
                        Stats =
                            new Stats
                                {
                                    AkumaNoMi = 0,
                                    Atk = 40,
                                    Def = 60,
                                    Haki = 20,
                                    Spd = 90
                                }
                    };
                
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
                Assert.AreEqual(charas.Count, 1);

                var org = db.Organizations.First(x => x.Name == "Straw Hat Pirate");
                var list = org.Characters.ToList();
                Assert.Greater(list.Count,0);

                var luffy = charas.First();
                var total = luffy.Stats.Total();
                Assert.AreNotEqual(total,0);
            }
        }

        [Test]
        public void Test2_1()
        {
            using (var db = new OpContext())
            {
                var luffy = db.Set<Character>().Single(x => x.Name == "Luffy");
                luffy.Name = "luffy";
                db.SaveChanges();

                var luffy2 = db.Set<Character>().Single(x => x.Name == "luffy");
                luffy.Name = "Luffy";
                db.SaveChanges();
            }
        }

        [Test]
        public void Test3()
        {
            var db = new OpContext();
            var luffy = db.Characters.FirstOrDefault(x => x.Name == "Luffy");
            if (luffy != null)
            {
                var luffyOrg = luffy.Organization;
                Assert.IsNotNull(luffyOrg);
            }
        }

        [Test]
        public void Test4()
        {
            var cS = new CharacterService();
            var luffy = cS.GetByName("Luffy");
            //var luffyStat = cS.Db.Stats.Single(x => x.Id == luffy.StatsId);
            luffy.Name = "luffy";
            cS.Update2(luffy);
            //cS.Db.SaveChanges();

            var luffy2 = cS.GetByName("Luffy");
            
            Assert.AreEqual(95,luffy2.Stats.Atk);

            luffy.Stats.Atk = 90;
            cS.Update2(luffy);
            
         }

        [Test]
        public void Test5()
        {
            var cS = new CharacterService();
            var luffy = new Character {Name = "Luffy"};
            var result = cS.Add(luffy);

            Assert.AreEqual(result.IsSuccessful,false);
        }

        [Test]
        public void Test6()
        {
            var cS = new CharacterService();
            var luffy = cS.GetByName("Luffy");
            Assert.AreEqual("Luffy", luffy.Name);
        }
    }
}