using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Demo.BLL.DTO.EmployeeDto;
using Demo.BLL.Services.Interface;
using Demo.DAL.Data.Repositries.interfcae;
using Demo.DAL.Models.EmployeeDepartment;

namespace Demo.BLL.Services.Classes
{
    public class EmployeeServices(IEmployeeRepositry _employeeRepositry,IMapper _mapper) : IEmployeeServices
    {
        public int Createemployee(CreatedEmployeeDto employee)
        {

            var Employee = _mapper.Map<CreatedEmployeeDto, Employee>(employee);

            return _employeeRepositry.Add(Employee);
        }

        public bool DeleteEmployee(int id)
        {

            // make soft Delete 
            var employee = _employeeRepositry.GetById(id);

            if (employee == null) return false;

            else
            {
                employee.IsDeleted = true;
                return _employeeRepositry.Upadte(employee) > 0 ? true : false;
            }
        }

        public IEnumerable<EmployeeDto> getAllEmployee(bool withTracking = false)
        {
            var employee = _employeeRepositry.GetAll(withTracking);

            // Auto mapping

            var returnedEmployeeDto=_mapper.Map<IEnumerable<Employee>,IEnumerable<EmployeeDto>> (employee);


            return returnedEmployeeDto;
        }

        public EmployeeDetailsDto? getEmployeeByID(int id)
        {
            var employee = _employeeRepositry.GetById(id);
            //auto mapping

           return employee == null ? null : _mapper.Map<Employee, EmployeeDetailsDto>(employee);

         


        }

        public int UpadteEmployee(UpdateEmployeeDto employee)
        {

            return _employeeRepositry.Upadte(_mapper.Map<UpdateEmployeeDto, Employee>(employee));
        }
    }
}
