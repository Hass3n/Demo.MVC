using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Demo.DAL.Models
{
    public class applicationUser:IdentityUser
    {

        public bool IAgree { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }
    }
}
