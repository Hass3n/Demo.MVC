using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DAL.Data.Repositries.interfcae;
using Demo.DAL.Models.EmployeeDepartment;

namespace Demo.DAL.Data.Repositries.Classes
{

    public class EmployeeRepsoitry(AppDpContext dbContext) : GenericRepositry<Employee>(dbContext), IEmployeeRepositry
    {
        public IQueryable<Employee> getEmployeeByAddress(string address)
        {
            throw new NotImplementedException();
        }
    }
}
