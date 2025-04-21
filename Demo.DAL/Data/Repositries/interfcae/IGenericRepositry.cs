using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DAL.Models;
using Demo.DAL.Models.DepartmentModel;

namespace Demo.DAL.Data.Repositries.interfcae
{
    public interface IGenericRepositry<TEntity> where TEntity:BaseEntity
    {

        // Get All
        IEnumerable<TEntity> GetAll(bool withTracking = false);

        //Get By Id
        TEntity GetById(int id);

        //upadte

        int Upadte(TEntity Entity);

        // Delete 
        int Delete(TEntity Entity);


        // Add

        int Add(TEntity Entity);

    }
}
