using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DAL.Models.EmployeeDepartment;

namespace Demo.DAL.Data.Repositries.interfcae
{
    public interface IEmployeeRepositry:IGenericRepositry<Employee>
    {

        IQueryable<Employee> getEmployeeByName(string Name);
    }
}
