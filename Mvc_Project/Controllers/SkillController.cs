using Mvc_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Project.Controllers
{
    public class SkillController : Controller
    {
        // GET: Skill

        PersonalDbEntities2 db = new PersonalDbEntities2();
        public ActionResult Index()
        {
            var result = db.TblSkill.ToList();

            return View(result);
        }


        [HttpGet]
        public ActionResult AddSkill()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSkill(TblSkill skill)
        {
            db.TblSkill.Add(skill);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult DeleteSkill(int id)
        {
            var result = db.TblSkill.Where(x => x.SkillID == id).FirstOrDefault();
            db.TblSkill.Remove(result);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditSkill(int id)
        {
            var result = db.TblSkill.Where(x => x.SkillID == id).FirstOrDefault();
           
      

            return View(result);
        }


        [HttpPost]
        public ActionResult EditSkill(TblSkill skill)
        {
            var result = db.TblSkill.Where(x => x.SkillID == skill.SkillID).FirstOrDefault();

            result.SkillTitle = skill.SkillTitle;
            result.SkillValue = skill.SkillValue;
            db.SaveChanges();



            return RedirectToAction("Index");

        }


    }
}