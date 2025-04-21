using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.DTO.DepartmentDto
{
   public class DepartmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Code { get; set; }

        public string? Description { get; set; }


        [Display(Name=" Data of Creation ")] // to Display this Name in view
        public DateOnly? DateOfCreation { get; set; } 



    }
}
