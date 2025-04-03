using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DAL.Data.Repositries.interfcae;
using Demo.DAL.Models;

namespace Demo.DAL.Data.Repositries.Classes
{
    public class DepartmentRepostry : IDepartmentRepostry
    {
        private readonly AppDpContext _dbContext;

        public DepartmentRepostry(AppDpContext dbContext) // ask Clr to create object
        {
            //_dbContext = new AppDpContext(); //open connection database
            _dbContext = dbContext;
        }
        public int Delete(Department Entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Department> GetAll()
        {
            throw new NotImplementedException();
        }

        public Department GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Add(Department Entity)
        {

            _dbContext.Departments.Add(Entity); // added
             
            return _dbContext.SaveChanges();  // upadte Database
        }

        public int Upadte(Department Entity)
        {
            throw new NotImplementedException();
        }
    }
}
