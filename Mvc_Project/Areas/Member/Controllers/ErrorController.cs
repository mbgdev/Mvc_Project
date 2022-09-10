using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Project.Areas.Member.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Member/Error
        public ActionResult Page404()
        {
            return View();
        }
    }
}