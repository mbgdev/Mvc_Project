using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Project.Controllers
{
    public class ServicesPartialController : Controller
    {
        // GET: ServicesPartial
        public PartialViewResult MyServicesPartial()
        {
            return PartialView();
        }


        public PartialViewResult PackagePartial()
        {
            return PartialView();
        }
    }
}