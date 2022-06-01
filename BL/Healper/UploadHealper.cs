using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.BL.Healper
{
    public class UploadHealper
    {
        public static string SaveFile(IFormFile fileUrl ,string folderPath)
        {
            String FilePath = Directory.GetCurrentDirectory() + "/wwwroot/Files/" + folderPath ;

            string FileName = Guid.NewGuid() + Path.GetFileName(fileUrl.FileName);
            string FinalPath = Path.Combine(FilePath, FileName);

            using (var Stream = new FileStream(FinalPath, FileMode.Create))
            {
                fileUrl.CopyTo(Stream);
            }
            return FileName; 
        }

        public static void RemoveFile(string FolderName , string RemovedFileName)
        {
            if (File.Exists(Directory.GetCurrentDirectory() + "/wwwroot/Files/" + FolderName + RemovedFileName))
            {
                File.Delete(Directory.GetCurrentDirectory() + "/wwwroot/Files/" + FolderName + RemovedFileName);
            }
        }
    }
}
