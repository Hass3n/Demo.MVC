using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.BLL.DTO.EmployeeDto;
using Demo.DAL.Models.EmployeeDepartment;

namespace Demo.BLL.Services.Interface
{
    public interface IEmployeeServices
    {

        // Get All Employee

        IEnumerable<EmployeeDto> getAllEmployee(bool withTracking = false);


        IEnumerable<EmployeeDto> searchEmployeeByName(string name);



        // Get Employee by Id

        EmployeeDetailsDto? getEmployeeByID(int id);

        // Create Employee

        int Createemployee(CreatedEmployeeDto employee);


        // upadte Employee

        int UpadteEmployee(UpdateEmployeeDto employee);


        // Delete Employee
        // soft Delete هنا هطبق 
        bool DeleteEmployee(int id);

    }
}
