using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using jsL.Context;
using jsL.Services;

namespace jsL.Controllers
{
    public class OrganizationController : Controller
    {
        //
        // GET: /Organization/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllOrg()
        {
            var oS = new OrganizationService(new OpContext());
            return oS.GetAll().ToJsonCamelResult();
        }

    }
}
