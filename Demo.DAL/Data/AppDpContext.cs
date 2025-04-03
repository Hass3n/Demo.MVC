using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Demo.DAL.Data.Configuration;
using Demo.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.DAL.Data
{
    public class AppDpContext :DbContext
    {
        public AppDpContext()
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("server=.;database=MVC_43;Trusted_Connection=true;");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

           // modelBuilder.ApplyConfiguration<Department>(new DepartmentConfiguration());

            // i you have manu configuration

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }

        // Bd set to convert proprty to table in database

        public DbSet<Department> Departments { get; set; }  // table
    }
}
