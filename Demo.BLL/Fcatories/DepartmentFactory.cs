using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Demo.BLL.DTO;
using Demo.DAL.Models;

namespace Demo.BLL.Fcatories
{
  static public class DepartmentFactory
    {

        // Extention method mapping
        public static DepartmentDto toDepartmentDto(this Department D)
        {
            return new DepartmentDto()
            {

                Id = D.Id,
                Name = D.Name,
                Description = D.Description,
                Code = D.Code,
                DateOfCreation = DateOnly.FromDateTime(D.CreatedOn.Value)
            };
        }



        public static DepartmentDetailsDto toDepartmentDetailsDto(this Department D)
        {

            return new DepartmentDetailsDto()
            {
                Id = D.Id,
                Name = D.Name,
                Description = D.Description,
                Code = D.Code,
                CreatedOn = DateOnly.FromDateTime(D.CreatedOn.Value),
                LastModifiedBy = D.LastModifiedBy,
                CreatedBy=D.CreatedBy,
               LastModifiedOn=D.LastModifiedOn

            };

        }


        public static Department ToEntity(this CreatedDepartmentDto departmentDto)
        {

            return new Department()
            {

                Name=departmentDto.Name,
                Code=departmentDto.code,
                Description=departmentDto.Description,
                CreatedOn=departmentDto.DateofCreation.ToDateTime(new TimeOnly()) // add time with Date

            };
        }


        public static Department ToEntity(this UpdateDepartmentDto updateDepartmentDto)
        {

            return new Department()
            {
                Id= updateDepartmentDto.Id,
                Name = updateDepartmentDto.Name,
                Code = updateDepartmentDto.code,
                Description = updateDepartmentDto.Description,
                CreatedOn = updateDepartmentDto.DateofCreation?.ToDateTime(new TimeOnly()) // add time with Date

            };

        }
    }
}
