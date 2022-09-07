using Mvc_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Project.Controllers
{
    public class HomeController : Controller
    {

        PersonalDbEntities2 db = new PersonalDbEntities2();


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            

            return View();
        }

        public ActionResult Contact()
        {
           

            return View();
        }

        public ActionResult Services()
        {


            return View();
        }



        public PartialViewResult HeaderPartial()
        {
            return PartialView();
        }

        public PartialViewResult NavBarPartial()
        {
            return PartialView();
        }

        public PartialViewResult BannerPartial()
        {
            return PartialView();
        }

        public PartialViewResult SkillPartial()
        {
            var result = db.TblSkill.ToList();
            return PartialView(result);
        }

        public PartialViewResult FeaturePartial()
        {
            var result = db.TblFeature.ToList();
            return PartialView(result);
        }

        public PartialViewResult ImagePartial()
        {

            ViewBag.mesaj = "C# ve .Net alanında yapmış olduğum projelere ait aşağıdan ulaşabilirsiniz, daha fazlası buradan ulaşabilrisinz.";
            var result = db.TblImage.ToList();
            return PartialView(result);
        }

        public PartialViewResult ExperiencePartial()
        {

            
            var result = db.TblExperience.ToList();
            return PartialView(result);
        }

        public PartialViewResult EducationPartial()
        {


            var result = db.TblEducation.ToList();
            return PartialView(result);
        }

        public PartialViewResult TestimonialPartial()
        {


            var result = db.TblTestimonial.ToList();
            return PartialView(result);
        }

    }
}