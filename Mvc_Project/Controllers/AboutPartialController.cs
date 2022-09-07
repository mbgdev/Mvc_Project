using Mvc_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Project.Controllers
{
    public class AboutPartialController : Controller
    {
        // GET: AboutPartial



        PersonalDbEntities2 db = new PersonalDbEntities2();

        public PartialViewResult MyAboutPartial()
        {
            return PartialView();
        }



        public PartialViewResult  ServicesPartial()
        {
            return PartialView();
        }
    



        public PartialViewResult StatisticsPartial()
        {
            ViewBag.v1 = db.TblSkill.Count();
            ViewBag.v2 = db.TblImage.Where(x => x.ImageCategory == "Csharp").Count();
            int id = db.TblExperience.Max(x => x.ExperienceID);
            ViewBag.v3 = db.TblExperience.Where(x => x.ExperienceID == id).Select(y => y.ExperinceTitle).FirstOrDefault();
            ViewBag.v4 = db.TblExperience.Where(x => x.ExperinceTitle == "Maui").Count();
            return PartialView();
        }


        public PartialViewResult SubscribePartial()
        {
            return PartialView();
        }
    }
}