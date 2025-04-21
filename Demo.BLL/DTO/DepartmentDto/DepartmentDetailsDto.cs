using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DAL.Models;

namespace Demo.BLL.DTO.DepartmentDto

{
    public class DepartmentDetailsDto
    {

        // constructor mapping

        //public DepartmentDetailsDto(Department department)
        //{
        //    Id = department.Id;
        //    Name = department.Name;
        //    Description = department.Description;
        //    Code = department.Code;
        //    CreatedOn = DateOnly.FromDateTime(department.CreatedOn.Value);
        //    LastModifiedBy = department.LastModifiedBy;
            

               
            
        //}

        public int Id { get; set; }  // Pk

        public int CreatedBy { get; set; } // contain userId created this Data

        public DateOnly? CreatedOn { get; set; } // Time of Created

        public int LastModifiedBy { get; set; }// contain userId Modified this Data

        public DateTime? LastModifiedOn { get; set; }//  contain Time Modified this Data[Automatic calaculated]

        public bool IsDeleted { get; set; } // soft deleted

        public string Name { get; set; } = string.Empty;

        public string Code { get; set; } = string.Empty;

        public string? Description { get; set; }
    }
}
