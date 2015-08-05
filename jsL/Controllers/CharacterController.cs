using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using jsL.ViewModels;

namespace jsL.Controllers
{
    public class CharacterController : Controller
    {
        //
        // GET: /Character/

        public ActionResult Index()
        {
            var person = new PersonVm();
            return View(person);
        }

    }
}
