using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Mvc_Project.Models;

namespace Mvc_Project.Areas.Member.Controllers
{
    public class LoginController : Controller
    {
        // GET: Member/Login

        PersonalDbEntities2 db = new PersonalDbEntities2();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
      



        [HttpPost]
        public ActionResult Index(TblMember p)
        {
            var result = db.TblMember.FirstOrDefault(x => x.MemberMail == p.MemberMail && x.MemberPassword == p.MemberPassword);
            int dk = (DateTime.Now.Hour*60)+(DateTime.Now.Minute);

            
            if (result != null && result.Lockout_End<dk)
            {
                result.Lockout_End = null;
                result.AccessFailedCount = null;
                db.SaveChanges();

                FormsAuthentication.SetAuthCookie(result.MemberMail, false);
                Session["MemberMail"] = result.MemberMail;
                return RedirectToAction("Index", "Profile");
            }
            else
            {
                var values = db.TblMember.FirstOrDefault(x => x.MemberMail == p.MemberMail);


                if (values.AccessFailedCount < 3 || values.AccessFailedCount==null)

                {

                    if (values.AccessFailedCount == null)

                        values.AccessFailedCount = 1;
                  
                    else

                        values.AccessFailedCount++;

                    db.SaveChanges();

                    return View();

                }


                if (values.AccessFailedCount == 3 && values.Lockout_End == null)
                {
                    int time = DateTime.Now.Hour * 60 + 1 + DateTime.Now.Minute;

                    string hour = DateTime.Now.Hour.ToString();

                    string minute = (DateTime.Now.Minute+2).ToString();

                    ViewBag.Message1 = "3 yanlış giriş denemesi yapılmıştır.";
                    ViewBag.Message2 = hour + ":" + minute + " kadar giriş yapamazsınız.";
                    values.Lockout_End = time;

                    db.SaveChanges();

                    return View();

                }

                if (values.AccessFailedCount == 3 && values.Lockout_End != null)
                {
                    string hour = (values.Lockout_End / 60).ToString();


                    string minute = ((values.Lockout_End % 60)+1).ToString();

                    ViewBag.Message1 = "3 yanlış giriş denemesi yapılmıştır.";
                    ViewBag.Message2 = hour + ":" + minute + " kadar giriş yapamazsınız.";

                    return View();


                }


                return RedirectToAction("Index", "Login");



            }
        }
    }
}