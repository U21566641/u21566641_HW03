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
            //Create FileModel List
            List<Models.FileModel> images = new List<Models.FileModel>();

            //Gets all files uploaded in Images folder
            String[] files = Directory.GetFiles(Server.MapPath("~/Media/Images"));

            //Iterates through files
            foreach (string file in files)
            {
                //Add each file to list             //Sets FileName in Model
                images.Add(new Models.FileModel { FileName = Path.GetFileName(file) });
            }

            return View(images);//Returns image to view
        }

        //Method to download file
        public FileResult DownloadFile(String fileName)
        {
            String filePath = Server.MapPath("~/Media/Images/") + fileName;
            byte[] bytes = System.IO.File.ReadAllBytes(filePath);

            return File(bytes, "application/octet-stream", fileName);
        }


        //Method to delete file
        public ActionResult DeleteFile(String fileName)
        {
            //Gets full path of file
            
            String filePath = Server.MapPath("~/Media/Images/") + fileName;
            //Creates new FileInfo object with the relevant file
            FileInfo file = new FileInfo(filePath);
            
            //Deletes file
            file.Delete();

            return RedirectToAction("Images");
        }
    }
}