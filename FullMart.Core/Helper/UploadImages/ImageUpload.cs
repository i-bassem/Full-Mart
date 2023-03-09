﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullMart.Core.Helper.UploadImages
{
    public static  class ImageUpload
    {

        public static string UploadFile(string _FolderPath, IFormFile _File)
        {

            try
            {

                // 1 )   Get Directory
                string FolderPath = Directory.GetCurrentDirectory() + "/wwwroot/" + _FolderPath;

                // 2)  // Get File Name
                string FileName = Guid.NewGuid() + Path.GetFileName(_File.FileName);

                // 3)  // Merge Path with File Name
                string FinalPath = Path.Combine(FolderPath, FileName);

                // 4)  // Save File As Streams "Data Overtime"
                using (var Stream = new FileStream(FinalPath, FileMode.Create))
                {
                    _File.CopyTo(Stream);
                }

                return FileName;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public static void RemoveFile(string FolderName, string FileName)
        {
            if (File.Exists(Directory.GetCurrentDirectory() + "/wwwroot/" + FolderName + FileName))
            {
                File.Delete(Directory.GetCurrentDirectory() + "/wwwroot/" + FolderName + FileName);
            }
        }

    }
}

