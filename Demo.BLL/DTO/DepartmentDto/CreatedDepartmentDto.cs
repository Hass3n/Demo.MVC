using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.DTO.DepartmentDto
{
  public  class CreatedDepartmentDto
    {

        [Required(ErrorMessage ="Name is required")]
        public String Name { get; set; } = null;// default value

        public String code { get; set; } = null;// default value

        public DateOnly DateofCreation { get; set; }

        public String? Description { get; set; }

    }
}
