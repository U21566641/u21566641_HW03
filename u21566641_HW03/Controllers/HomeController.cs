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

        //Method to add file to folder
        [HttpPost]
        public ActionResult Home(HttpPostedFileBase postedFile, String option)
        {
            var filePath = "";

            //Compares the file option (document/video/image) and sets relevant filepath
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
            postedFile.SaveAs(path);//Saves file to relevant folder


            return RedirectToAction("Home");
        }


        public ActionResult AboutMe()
        {
            return View();
        }
        
    }
}