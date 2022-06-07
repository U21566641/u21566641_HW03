using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace u21566641_HW03.Controllers
{
    public class ImageController : Controller
    {
        // GET: Image
        public ActionResult Images()
        {
            List<Models.FileModel> images = new List<Models.FileModel>();

            String[] files = Directory.GetFiles(Server.MapPath("~/Media/Images"));

            foreach (string file in files)
            {
                images.Add(new Models.FileModel { FileName = Path.GetFileName(file) });
            }

            return View(images);
        }

        public FileResult DownloadFile(String fileName)
        {
            String filePath = Server.MapPath("~/Media/Images/") + fileName;
            byte[] bytes = System.IO.File.ReadAllBytes(filePath);

            return File(bytes, "application/octet-stream", fileName);
        }

        public ActionResult DeleteFile(String fileName)
        {
            String filePath = Server.MapPath("~/Media/Images/") + fileName;
            FileInfo file = new FileInfo(filePath);
            file.Delete();

            return RedirectToAction("Images");
        }
    }
}