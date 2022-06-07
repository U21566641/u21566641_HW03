using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace u21566641_HW03.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Home()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Home(HttpPostedFileBase postedFile, String option)
        {
            var filePath = "";

             switch (option)
             {
                 case "document":
                     filePath = Server.MapPath("~/Media/Documents");
                     break;
                 case "image":
                     filePath = Server.MapPath("~/Media/Images");
                     break;
                 case "video":
                     filePath = Server.MapPath("~/Media/Videos");
                     break;
             }
             


            var path = Path.Combine(filePath, postedFile.FileName);
            postedFile.SaveAs(path);


            return RedirectToAction("Home");
        }


        public ActionResult AboutMe()
        {
            return View();
        }
        
    }
}