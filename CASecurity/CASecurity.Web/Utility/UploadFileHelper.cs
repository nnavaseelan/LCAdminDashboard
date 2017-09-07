using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace CASecurity.Web.Utility
{
    public class UploadFileHelper
    {
        private static string appFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Content", "Documents");

        public static string Save(string id, HttpPostedFileBase file)
        {
            if (file == null)
                throw new ArgumentNullException("Empty File.");

            var fileName = file.FileName;
            var subPath = Path.Combine(appFolderPath, id);

            if (!Directory.Exists(subPath))
                Directory.CreateDirectory(subPath);

            var pathString = Path.Combine(subPath, fileName);

            int i = 1;
            while (File.Exists(pathString))
            {
                fileName = string.Format("{0}_{1}", fileName, i);
                pathString = Path.Combine(subPath, fileName);
                i++;
            }

            file.SaveAs(pathString);
            return pathString;
        }
    }
}