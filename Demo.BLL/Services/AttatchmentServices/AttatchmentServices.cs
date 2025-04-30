using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Demo.BLL.Services.AttatchmentServices
{
    public class AttatchmentServices : IAttatchmantServices
    {
        List<string> AllowedExtention = [".png", ".jpg", ".jpeg"];

        const int maxSixe = 2_097_152; //2Mp
        public string? Upload(IFormFile file, string folderName)
        {

            //1.Check Extension
            var extention = Path.GetExtension(file.FileName);

            if (!AllowedExtention.Contains(extention)) return null;

            //2.Check Size
            if (file.Length == 0 || file.Length > maxSixe) return null;
            //3.Get Located Folder Path

            // first way
            //var folderPath = $"{Directory.GetCurrentDirectory()}\\wwwroot\\Files\\{folderName}";


            // second way

            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files", folderName);



            //4.Make Attachment Name Unique-- GUID

            var fileName = $"{Guid.NewGuid()}_{file.FileName}"; //make file Name unique
            //5.Get File Path 

            var filePath = Path.Combine(folderPath, fileName);

            //6.Create File Stream To Copy File[Unmanaged]

            // using  key word using to close connextion beacause file straem is Unmanaged in memmory
            using FileStream fs = new FileStream(filePath, FileMode.Create);

            //7.Use Stream To Copy File

            file.CopyTo(fs);
            //8.Return FileName To Store In Database

            return fileName;

        }

        public bool Delete(string fileName,string folderName)
        {

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files", folderName,fileName);


            if (!File.Exists(filePath)) return false;

            else
            {
                File.Delete(filePath);
                return true;
            }



        }

   
    }
}
