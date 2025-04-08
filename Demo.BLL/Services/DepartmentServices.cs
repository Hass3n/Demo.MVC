using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.BLL.DTO;
using Demo.BLL.Fcatories;
using Demo.DAL.Data.Repositries.interfcae;
using Demo.DAL.Models;

namespace Demo.BLL.Services
{
    public class DepartmentServices(IDepartmentRepostry _departmentRepostry) : IDepartmentServices
    {
        // private readonly IDepartmentRepostry _departmentRepostry = departmentRepostry;

        // Get All Department


        public IEnumerable<DepartmentDto> GetAllDepartments()
        {
            var departments = _departmentRepostry.GetAll();

            #region Manual mapping
            // Manual mapping --- make map to Department to  DepartmentDto
            //var departmentToReturn = departments.Select(D => new DepartmentDto()
            //{

            //    Id = D.Id,
            //    Name = D.Name,
            //    Description = D.Description,
            //    Code = D.Code,
            //    DateOfCreation = DateOnly.FromDateTime(D.CreatedOn.Value)

            //}); 
            #endregion


            #region Extention mapping


            return departments.Select(D => D.toDepartmentDto());


            #endregion


        }


        public DepartmentDetailsDto? GetDepartmentById(int id)
        {
            var department = _departmentRepostry.GetById(id);
            #region Manula mapping
            //if (department == null) return null;
            //else
            //{
            //    // Manual mapping
            //    var departmentToReturn = new DepartmentDetailsDto()
            //    {
            //        Id = department.Id,
            //        Name = department.Name,
            //        Description = department.Description,
            //        Code = department.Code,
            //        CreatedOn = DateOnly.FromDateTime(department.CreatedOn.Value),
            //        LastModifiedOn = department.LastModifiedOn,
            //        IsDeleted=department.IsDeleted




            //    }; 
            #endregion

            #region Manual mapping
            //return department is null ? null : new DepartmentDetailsDto()
            //{
            //    Id = department.Id,
            //    Name = department.Name,
            //    Description = department.Description,
            //    Code = department.Code,
            //    CreatedOn = DateOnly.FromDateTime(department.CreatedOn.Value),
            //    LastModifiedOn = department.LastModifiedOn,
            //    IsDeleted = department.IsDeleted




            //}; 
            #endregion





            #region constructor mapping
            //return department is null ? null : new DepartmentDetailsDto(department)
            //{





            //};

            #endregion


            #region Extention mapping

            return department is null ? null : department.toDepartmentDetailsDto();
            #endregion



        }



        public int AddDepartment(CreatedDepartmentDto departmentDto)
        {

            var department = departmentDto.ToEntity();
            return _departmentRepostry.Add(department);
        }

        public int UpdateDepartment(UpdateDepartmentDto departmentDto)
        {

            return _departmentRepostry.Upadte(departmentDto.ToEntity());
        }

        public bool DeleteDepartment(int id)
        {
            var department = _departmentRepostry.GetById(id);

            if (department is null) return false;

            else
            {
                int result = _departmentRepostry.Delete(department);
                return result > 0 ? true : false;

            }




        }

    }

}
