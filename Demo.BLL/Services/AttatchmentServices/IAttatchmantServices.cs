using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Demo.BLL.Services.AttatchmentServices
{
    public interface IAttatchmantServices
    {
        public string? Upload(IFormFile fromfile, string folderName);

        public bool Delete(string fileName, string folderName);
   


    }
}
