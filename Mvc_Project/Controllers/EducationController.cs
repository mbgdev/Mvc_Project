using Mvc_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Project.Controllers
{
    public class EducationController : Controller
    {
        // GET: Education
        PersonalDbEntities2 db = new PersonalDbEntities2();

        public ActionResult Index()
        {

            var result = db.TblEducation.ToList();

            return View(result);
        }


        [HttpGet]
        public ActionResult AddEducation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEducation(TblEducation education)
        {
            db.TblEducation.Add(education);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult DeleteEducation(int id)
        {
            var result = db.TblEducation.Where(x => x.EducationID == id).FirstOrDefault();
            db.TblEducation.Remove(result);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditEducation(int id)
        {
            var result = db.TblEducation.Where(x => x.EducationID == id).FirstOrDefault();



            return View(result);
        }


        [HttpPost]
        public ActionResult EditEducation(TblEducation education)
        {
            var result = db.TblEducation.Where(x => x.EducationID == education.EducationID).FirstOrDefault();

            result.EducationTitle = education.EducationTitle;
            result.EduationDate = education.EduationDate;
            result.EducationDescription = education.EducationDescription;
            db.SaveChanges();



            return RedirectToAction("Index");

        }

    }
}