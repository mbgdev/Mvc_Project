using Mvc_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Project.Controllers
{
    public class FeatureController : Controller
    {
        // GET: Feature
       
        PersonalDbEntities2 db = new PersonalDbEntities2();

        public ActionResult Index()
        {

            var result = db.TblFeature.ToList();

            return View(result);
        }


        [HttpGet]
        public ActionResult AddFeature()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddFeature(TblFeature feature)
        {
            db.TblFeature.Add(feature);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult DeleteFeature(int id)
        {
            var result = db.TblFeature.Where(x => x.FeatureID == id).FirstOrDefault();
            db.TblFeature.Remove(result);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditFeature(int id)
        {
            var result = db.TblFeature.Where(x => x.FeatureID == id).FirstOrDefault();




            return View(result);
        }


        [HttpPost]
        public ActionResult EditFeature(TblFeature feature)
        {
            var result = db.TblFeature.Where(x => x.FeatureID == feature.FeatureID).FirstOrDefault();

            result.FeatureTitle = feature.FeatureTitle; 
            result.FeatureLogo = feature.FeatureLogo;
            result.FeatureDescription = feature.FeatureDescription;


            db.SaveChanges();



            return RedirectToAction("Index");

        }
    }
}