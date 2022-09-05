using Mvc_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Project.Controllers
{
    public class ExperienceController : Controller
    {
        // GET: Experience

        PersonalDbEntities2 db = new PersonalDbEntities2();

        public ActionResult Index()
        {
            var result = db.TblExperience.ToList();
            return View(result);
        }

        [HttpGet]
        public ActionResult AddExperience()
        {
          
            return View();
        }

        [HttpPost]
        public ActionResult AddExperience(TblExperience experience)
        {
            db.TblExperience.Add(experience);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteExperience(int id)
        {
            var result = db.TblExperience.Where(x => x.ExperienceID == id).FirstOrDefault();

            db.TblExperience.Remove(result);
            db.SaveChanges();

            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult EditExperience(int id)
        {

            var result = db.TblExperience.Where(x => x.ExperienceID == id).FirstOrDefault();



            return View(result);
           
        }


        [HttpPost]
        public ActionResult EditExperience(TblExperience experience)
        {
            var result = db.TblExperience.Where(x => x.ExperienceID == experience.ExperienceID).FirstOrDefault();

            result.ExperinceTitle = experience.ExperinceTitle;
            result.ExperienceDate = experience.ExperienceDate;
            result.ExperienceDescription = experience.ExperienceDescription;
            db.SaveChanges();

            return RedirectToAction("Index");

        }


    }
}