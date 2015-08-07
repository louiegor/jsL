using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using jsL.Context;
using jsL.Models;
using jsL.ViewModels;

namespace jsL.Controllers
{
    public class CharacterController : Controller
    {
        //
        // GET: /Character/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            if (file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/base/images"), fileName);
                file.SaveAs(path);
            }

            return RedirectToAction("Index");
        }

        public class OrgType
        {
            public string Name { get; set; }
        }

        public ActionResult GetByOrg(OrgType type)
        {
            var db = new OpContext();
            var charaList = db.Organizations.Where(x => x.Name == type.Name).ToList();
            //return charaList.ToJsonResult();

            var list = new List<Character>
                {
                    new Character{Name = "Luffy" },new Character{Name = "Nami" },new Character{Name = "Zoro" }
                };
            var test1 = list.ToJsonResult();
            var test2 = list.ToJsonCamelResult();
            return test2;
        }
    }
}
