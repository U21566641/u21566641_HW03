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
            List<Models.FileModel> videos = new List<Models.FileModel>();

            String[] files = Directory.GetFiles(Server.MapPath("~/Media/Videos"));

            foreach (string file in files)
            {
                videos.Add(new Models.FileModel { FileName = Path.GetFileName(file) });
            }

            return View(videos);
        }
        public FileResult DownloadFile(String fileName)
        {
            String filePath = Server.MapPath("~/Media/Videos/") + fileName;
            byte[] bytes = System.IO.File.ReadAllBytes(filePath);

            return File(bytes, "application/octet-stream", fileName);
        }

        public ActionResult DeleteFile(String fileName)
        {
            String filePath = Server.MapPath("~/Media/Videos/") + fileName;
            FileInfo file = new FileInfo(filePath);
            file.Delete();

            return RedirectToAction("Index");
        }
    }
}