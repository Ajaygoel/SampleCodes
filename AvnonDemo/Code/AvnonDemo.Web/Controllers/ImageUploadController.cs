using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace AvnonDemo.Web.Controllers
{
    public class ImageUploadController : Controller
    {
        [HttpPost]
        public String fileuploader(HttpPostedFileBase files)
        {
            String ret = "error";
            string[] AllowedFileExtensions = new string[] { ".jpg", ".png", };
            int MaxContentLength = 1024 * 1024 * 10; //10 MB
            if (files == null || files.ContentLength == 0)
            {
                return ret;
            }
            else if (!AllowedFileExtensions.Contains(files.FileName.Substring(files.FileName.LastIndexOf('.'))))
            {
                return "error, Please select jpg,png File Only";
            }
            else if (files.ContentLength > MaxContentLength)
            {
                return "error, Max 10 Mb file is allow";
            }
            var fileName = Path.GetFileName(files.FileName);
            fileName = createUniqueFileName(fileName);
            var path = Path.Combine(Server.MapPath("~/Uploads"), fileName);
            files.SaveAs(path);
            var displayFilePath = "/Uploads/" + fileName;
            return "Success," + displayFilePath + "," + files.ContentLength;
        }

        public static String createUniqueFileName(String fileName)
        {

            String ext = fileName.Substring(fileName.LastIndexOf(".") + 1);
            fileName = fileName.Substring(0, (fileName.LastIndexOf(".")));
            fileName = Regex.Replace(fileName, "[^A-Za-z0-9]", "");
            if (fileName.Length > 20)
            {
                fileName = fileName.Substring(fileName.Length - 20);
            }
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var uqiueName = new string(Enumerable.Repeat(chars, 15).Select(s => s[random.Next(s.Length)]).ToArray());
            return uqiueName + "_" + fileName + "." + ext;
        }

    }
}
