﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Newtonsoft.Json;


namespace jsL.Controllers
{
    public class Person
    {
        public string Name { get; set; }
        public string Organization { get; set; }
    }

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        [HttpPost]
        public JsonResult GetId(string name)
        {
            try
            {
                string x = name;
                return Json(new { success = true });
            }
            catch (Exception ex)
            {

                return Json(new { success = false, errorMessage = ex.Message });
            }

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

        //public static ToJson (List<T> aList)
        //{
        //    var jsonSerialiser = new JavaScriptSerializer();
        //    var json = jsonSerialiser.Serialize(aList);
        //}

//        public static T ConfigSetting<T>(string settingName)
//{  
//    return /* code to convert the setting to T... */
//}
    }

    public static class Helper
    {

        public static JsonResult ToJsonResult<T>(this T obj)
        {
            return new JsonResult { Data = obj, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }

}
