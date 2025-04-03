using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DAL.Models;

namespace Demo.DAL.Data.Repositries.interfcae
{
    public interface IDepartmentRepostry
    {
        // Get All
        IEnumerable<Department> GetAll();

        //Get By Id
        Department GetById(int id);

        //upadte

        int Upadte(Department Entity);

        // Delete 
        int Delete(Department Entity);


        // Add

        int Add(Department Entity);
    }
}
