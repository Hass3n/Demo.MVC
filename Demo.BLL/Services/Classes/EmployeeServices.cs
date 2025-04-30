using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Demo.BLL.DTO.EmployeeDto;
using Demo.BLL.Services.AttatchmentServices;
using Demo.BLL.Services.Interface;
using Demo.DAL.Data.Repositries.interfcae;
using Demo.DAL.Models.EmployeeDepartment;

namespace Demo.BLL.Services.Classes
{
    public class EmployeeServices(InUnitOfWork _Iunitwork /*IEmployeeRepositry _employeeRepositry*/, IMapper _mapper,IAttatchmantServices _attatchmantServices) : IEmployeeServices
    {
        public int Createemployee(CreatedEmployeeDto employee)
        {

            var Employee = _mapper.Map<CreatedEmployeeDto, Employee>(employee);

            if(employee.Image is not null)
            {

                Employee.imageName = _attatchmantServices.Upload(employee.Image,"Images");
            }

            _Iunitwork.EmployeeRepositry.Add(Employee);

            return _Iunitwork.SaveChanges();

        }

        public bool DeleteEmployee(int id)
        {

            // make soft Delete 
            var employee = _Iunitwork.EmployeeRepositry.GetById(id);

            if (employee == null) return false;

            else
            {
                employee.IsDeleted = true;
            

                _Iunitwork.EmployeeRepositry.Upadte(employee);

                int result = _Iunitwork.SaveChanges();
                if(result>0)
                {

                    // soft Delete   لكن مش همسحها من الداتا بيز لاني بعمل root/Images انا هنا بمسح الصوره من ملف السيرفر الي عندي في 

                    _attatchmantServices.Delete(employee.imageName, "Images");
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }

        public IEnumerable<EmployeeDto> getAllEmployee(bool withTracking = false)
        {
            var employee = _Iunitwork.EmployeeRepositry.GetAll(withTracking);

            // Auto mapping

            var returnedEmployeeDto=_mapper.Map<IEnumerable<Employee>,IEnumerable<EmployeeDto>> (employee);


            return returnedEmployeeDto;
        }


        public IEnumerable<EmployeeDto> searchEmployeeByName(string Name)
        {


            var employee = _Iunitwork.EmployeeRepositry.getEmployeeByName(Name.ToLower());
            


            var returnedEmployeeDtoSearch = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(employee);





            return returnedEmployeeDtoSearch;
        }


        public EmployeeDetailsDto? getEmployeeByID(int id)
        {
            var employee = _Iunitwork.EmployeeRepositry.GetById(id);
            //auto mapping

           return employee == null ? null : _mapper.Map<Employee, EmployeeDetailsDto>(employee);

         


        }

        public int UpadteEmployee(UpdateEmployeeDto employee)
        {

             _Iunitwork.EmployeeRepositry.Upadte(_mapper.Map<UpdateEmployeeDto, Employee>(employee));

            return _Iunitwork.SaveChanges();
        }

    }
}
