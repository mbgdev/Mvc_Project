using Mvc_Project.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Project.Controllers
{
    public class ImageController : Controller
    {
        // GET: Image
        PersonalDbEntities2 db = new PersonalDbEntities2();

        public ActionResult Index()
        {
            var result = db.TblImage.ToList();
            return View(result);
        }


        [HttpGet]
        public ActionResult AddImage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddImage(TblImage image)
        {
            if (Request.Files.Count > 0)
            {
                string newFile = Guid.NewGuid().ToString();
                string fileName = Path.GetFileName(Request.Files[0].FileName);
                string newFileName = fileName.Replace(fileName, newFile);
                string expansionImage = Path.GetExtension(Request.Files[0].FileName);
                string pathImage = "/Content/assets/images/" + newFileName + expansionImage;

                Request.Files[0].SaveAs(Server.MapPath(pathImage));
                image.ImageUrl = "/Content/assets/images/" + newFileName + expansionImage;
            }


            db.TblImage.Add(image);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult DeleteImage(int id)
        {
            var result = db.TblImage.Where(x => x.ImageID == id).FirstOrDefault();
            db.TblImage.Remove(result);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditImage(int id)
        {
            var result = db.TblImage.Where(x => x.ImageID == id).FirstOrDefault();



            return View(result);
        }


        [HttpPost]
        public ActionResult EditImage(TblImage image)
        {
            var result = db.TblImage.Where(x => x.ImageID == image.ImageID).FirstOrDefault();

          


            result.ImageUrl = image.ImageUrl;
            result.ImageDescription = image.ImageDescription;
            db.SaveChanges();



            return RedirectToAction("Index");

        }




    }
}