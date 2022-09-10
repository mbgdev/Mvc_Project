using Mvc_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Project.Areas.Member.Controllers
{

    [Authorize]
    public class ProfileController : Controller
    {
        // GET: Member/Profile


        PersonalDbEntities2 db = new PersonalDbEntities2();

        public ActionResult Index()
        {
            
            return View();
        }


        [HttpGet]
        public ActionResult EditProfile()
        {
            var mail = Session["MemberMail"].ToString();
          
            var values = db.TblMember.Where(x => x.MemberMail == mail).FirstOrDefault();
            return View(values);
        }
        [HttpPost]
        public ActionResult EditProfile(TblMember p)
        {

            var mail = Session["MemberMail"].ToString();

            var values = db.TblMember.Where(x => x.MemberMail == mail).FirstOrDefault();
            values.MemberName = p.MemberName;
            values.MemberSurname = p.MemberSurname;
            values.MemberPassword= p.MemberPassword;
            db.SaveChanges();

          return RedirectToAction("Index");
        }


    }
}