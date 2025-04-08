using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.DTO
{
  public  class UpdateDepartmentDto
    {

        public int Id { get; set; }
        public String Name { get; set; } = string.Empty;// default value

        public String code { get; set; } = string.Empty;// default value

        public DateOnly DateofCreation { get; set; }

        public String? Description { get; set; }
    }
}
