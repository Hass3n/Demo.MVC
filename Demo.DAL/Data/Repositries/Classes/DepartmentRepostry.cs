using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DAL.Data.Repositries.interfcae;
using Demo.DAL.Models.DepartmentModel;
using Microsoft.EntityFrameworkCore;

namespace Demo.DAL.Data.Repositries.Classes
{
    // primary construtor prevent to create paramtless constructor
    public class DepartmentRepostry(AppDpContext dbContext) : GenericRepositry<Department>(dbContext), IDepartmentRepostry
    {
        public IQueryable<Department> GetAllDepartment()
        {
            throw new NotImplementedException();
        }
    }


}
