using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using jsL.Context;
using jsL.Models;


namespace jsL.Controllers
{
    public class Person
    {
        public string Name { get; set; }
        public string Organization { get; set; }
    }

    public class File
    {
        public string Name { get; set; }
    }

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public class ViewModel
        {
            public string NewName { get; set; }
        }

        public class CharaVm
        {
            public int OrgId { get; set; }
            public string CharaName { get; set; }
        }

        public ActionResult AddCharacter(CharaVm c)
        {
            var opContext = new OpContext();
            var organizations = new List<Organization>();
            var org = opContext.Organizations.Single(x => x.Id == c.OrgId);
            organizations.Add(org);
            opContext.Characters.Add(new Character{Name = c.CharaName, Organization = org});
            opContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AddOrganization(string orgName)
        {
            var opContext = new OpContext();
            opContext.Organizations.Add(new Organization {Name = orgName});
            opContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetAllOrg()
        {
            var opContext = new OpContext();
            var list = opContext.Organizations.ToList();
            return list.ToJsonCamelResult();
        }

        [HttpPost]
        public ActionResult PostFile(HttpPostedFileBase file)
        {

            if (file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/base/images"), fileName);
                //var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
                file.SaveAs(path);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult PostPerson(Person p)
        {
            return p.ToJsonResult();
        }

        [HttpPost]
        public JsonResult GetId(ViewModel vm)
        {
            return vm.ToJsonResult();
        }

        public string DataColor()
        {
            PersonJson();
            return "Red";
        }

        public JsonResult PersonJson()
        {
            var list = GetPersonList();
            return list.ToJsonResult();

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public List<Person> GetPersonList()
        {
            var list = new List<Person>
                           {
                               new Person {Name = "Luffy", Organization = "Straw Hat Pirate"},
                               new Person {Name = "Nami", Organization = "Straw Hat Pirate"},
                               new Person {Name = "Zoro", Organization = "Straw Hat Pirate"},
                               new Person {Name = "Sanji", Organization = "Straw Hat Pirate"},
                               new Person {Name = "Usopp", Organization = "Straw Hat Pirate"},
                               new Person {Name = "Chopper", Organization = "Straw Hat Pirate"},
                               new Person {Name = "Robin", Organization = "Straw Hat Pirate"},
                               new Person {Name = "Franky", Organization = "Straw Hat Pirate"},
                               new Person {Name = "Brook", Organization = "Straw Hat Pirate"}
                           };
            return list;
        }

        public ActionResult Yes()
        {
            return View();
        }

        public ActionResult Testing()
        {
            return View();
        }
    }

    public static class Helper
    {

        public static JsonResult ToJsonResult<T>(this T obj)
        {
            return new JsonResult() {Data = obj, JsonRequestBehavior = JsonRequestBehavior.AllowGet};
        }

        public static ContentResult ToJsonCamelResult<T>(this T obj)
        {
            var settings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
            var jsonObj = JsonConvert.SerializeObject(obj, Formatting.Indented, settings);
            //return new JsonResult { Data = jsonObj, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            return new ContentResult
            {
                ContentType = "text/plain",
                Content = jsonObj,
                ContentEncoding = Encoding.UTF8
            };

            
        }

        

    }

}
