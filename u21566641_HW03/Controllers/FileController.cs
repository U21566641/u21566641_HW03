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
            //Create FileModel List
            List<Models.FileModel> documents = new List<Models.FileModel>();

            //Gets all files uploaded in Documents folder
            String[] files = Directory.GetFiles(Server.MapPath("~/Media/Documents"));

            //Iterates through files
            foreach (string file in files)
            {
                //Add each file to list             //Sets FileName in Model
                documents.Add(new Models.FileModel { FileName = Path.GetFileName(file) });
            }

            return View(documents);
        }

        //Method to download file
        public FileResult DownloadFile(String fileName)
        {
            String filePath = Server.MapPath("~/Media/Documents/") + fileName;
            byte[] bytes = System.IO.File.ReadAllBytes(filePath);

            return File(bytes, "application/octet-stream", fileName);
        }

        //Method to delete file
        public ActionResult DeleteFile(String fileName)
        {
            //Gets full path of file
            String filePath = Server.MapPath("~/Media/Documents/") + fileName;
            FileInfo file = new FileInfo(filePath);
            file.Delete();

            return RedirectToAction("Files");
        }
    }
}