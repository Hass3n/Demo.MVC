using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DAL.Data.Repositries.interfcae;
using Demo.DAL.Models;
using Microsoft.EntityFrameworkCore;

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
            _dbContext.Departments.Remove(Entity);
            return _dbContext.SaveChanges();
        }

        public IEnumerable<Department> GetAll(bool withTracking = false)
        {
            if (withTracking)
            {
                return _dbContext.Departments.ToList();
            }
            else
                return _dbContext.Departments.AsNoTracking().ToList();
        }

        public Department GetById(int id)
        {

            // serch first local if data found returen Data if data not local serch in Database
            return _dbContext.Departments.Find(id);
        }

        public int Add(Department Entity)
        {

            _dbContext.Departments.Add(Entity); // added
             
            return _dbContext.SaveChanges();  // upadte Database
        }

        public int Upadte(Department Entity)
        {
            _dbContext.Departments.Update(Entity);
         return   _dbContext.SaveChanges();
        }
    }
}
