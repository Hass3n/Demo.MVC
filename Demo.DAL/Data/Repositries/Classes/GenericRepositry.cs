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
    public class GenericRepositry<TEntity>(AppDpContext _dbContext):IGenericRepositry<TEntity> where TEntity : BaseEntity
    {

        public void Delete(TEntity Entity)
        {
            _dbContext.Set<TEntity>().Remove(Entity);
            //return _dbContext.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll(bool withTracking = false)
        {
            if (withTracking)
            {
                return _dbContext.Set<TEntity>().Where(E=>E.IsDeleted!=true).ToList();
            }
            else
                return _dbContext.Set<TEntity>().Where(E=>E.IsDeleted!=true).AsNoTracking().ToList();
        }

        public TEntity GetById(int id)
        {

            // serch first local if data found returen Data if data not local serch in Database
            return _dbContext.Set<TEntity>().Find(id);
        }

        public void Add(TEntity Entity)
        {

            _dbContext.Set<TEntity>().Add(Entity); // added

            //return _dbContext.SaveChanges();  // upadte Database
        }

        public void Upadte(TEntity Entity)
        {
            _dbContext.Set<TEntity>().Update(Entity);
            //return _dbContext.SaveChanges();
        }
    }
}
