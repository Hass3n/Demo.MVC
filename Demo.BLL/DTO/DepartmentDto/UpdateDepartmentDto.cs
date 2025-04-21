using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.DTO.DepartmentDto


{
    public  class UpdateDepartmentDto
    {

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;// default value

        public string code { get; set; } = string.Empty;// default value

        public DateOnly? DateofCreation { get; set; }

        public string? Description { get; set; }
    }
}
