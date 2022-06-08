using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace u21566641_HW03.Controllers
{
    public class VideoController : Controller
    {
        // GET: Video
        public ActionResult Index()
        {
            //Create FileModel List
            List<Models.FileModel> videos = new List<Models.FileModel>();

            //Gets all files uploaded in Videos folder
            String[] files = Directory.GetFiles(Server.MapPath("~/Media/Videos"));

            //Iterates through files
            foreach (string file in files)
            {
                //Add each file to list             //Sets FileName in Model
                videos.Add(new Models.FileModel { FileName = Path.GetFileName(file) });
            }

            return View(videos);
        }

        //Method to download file
        public FileResult DownloadFile(String fileName)
        {
            String filePath = Server.MapPath("~/Media/Videos/") + fileName;
            byte[] bytes = System.IO.File.ReadAllBytes(filePath);

            return File(bytes, "application/octet-stream", fileName);
        }

        //Method to delete file
        public ActionResult DeleteFile(String fileName)
        {
            //Gets full path of file
            String filePath = Server.MapPath("~/Media/Videos/") + fileName;
            FileInfo file = new FileInfo(filePath);
            file.Delete();

            return RedirectToAction("Index");
        }
    }
}