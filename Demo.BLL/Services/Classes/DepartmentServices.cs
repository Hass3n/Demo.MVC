using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.BLL.DTO.DepartmentDto;
using Demo.BLL.Fcatories;
using Demo.BLL.Services.Interface;
using Demo.DAL.Data.Repositries.interfcae;
using Demo.DAL.Models;

namespace Demo.BLL.Services.Classes
{
    public class DepartmentServices(InUnitOfWork _uUnitOfWork /*IDepartmentRepostry _departmentRepostry*/) : IDepartmentServices
    {
        // private readonly IDepartmentRepostry _departmentRepostry = departmentRepostry;

        // Get All Department


        public IEnumerable<DepartmentDto> GetAllDepartments()
        {
            var departments = _uUnitOfWork.DepartmentRepostry.GetAll();

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
            var department = _uUnitOfWork.DepartmentRepostry.GetById(id);
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



        public int  AddDepartment(CreatedDepartmentDto departmentDto)
        {

            var department = departmentDto.ToEntity();
             _uUnitOfWork.DepartmentRepostry.Add(department);

            return _uUnitOfWork.SaveChanges();
            
        }

        public int UpdateDepartment(UpdateDepartmentDto departmentDto)
        {

             _uUnitOfWork.DepartmentRepostry.Upadte(departmentDto.ToEntity());

            return _uUnitOfWork.SaveChanges();
        }

        public bool DeleteDepartment(int id)
        {
            var department = _uUnitOfWork.DepartmentRepostry.GetById(id);

            if (department is null) return false;

            else
            {
                _uUnitOfWork.DepartmentRepostry.Delete(department);
                return _uUnitOfWork.SaveChanges() > 0 ? true : false;

            }




        }

    }

}
