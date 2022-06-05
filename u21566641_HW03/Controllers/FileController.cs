using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace u21566641_HW03.Controllers
{
    public class FileController : Controller
    {
        // GET: File
        public ActionResult Files()
        {

            List<Models.FileModel> documents = new List<Models.FileModel>();

            String[] files = Directory.GetFiles(Server.MapPath("~/Media/Documents"));

            foreach (string file in files)
            {
                documents.Add(new Models.FileModel { FileName = Path.GetFileName(file) });
            }

            return View(documents);
        }

        public FileResult DownloadFile(String fileName)
        {
            String filePath = Server.MapPath("~/Media/Documents/") + fileName;
            byte[] bytes = System.IO.File.ReadAllBytes(filePath);

            return File(bytes, "application/octet-stream", fileName);
        }

        public ActionResult DeleteFile(String fileName)
        {
            String filePath = Server.MapPath("~/Media/Documents/") + fileName;
            FileInfo file = new FileInfo(filePath);
            file.Delete();

            return RedirectToAction("Files");
        }
    }
}