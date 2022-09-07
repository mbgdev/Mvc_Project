using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Project.Controllers
{
    public class ContactPartialController : Controller
    {
        // GET: ContactPartial
        public PartialViewResult FormPartial()
        {
            return PartialView();
        }


        public PartialViewResult AddressPartial()
        {
            return PartialView();
        }
    }
}