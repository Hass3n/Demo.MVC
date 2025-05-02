using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Demo.DAL.Data.Configuration;
using Demo.DAL.Models;
using Demo.DAL.Models.DepartmentModel;
using Demo.DAL.Models.EmployeeDepartment;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Demo.DAL.Data
{

    // DbSet وهي بتعملهم ÷Identity user ,Identity role  ذي  security Module  وكذلك عنها السبع جاول الخاصين ب AppDpContext عندها  IdentityDbContext 
    public class AppDpContext/* :DbContext*/ :IdentityDbContext<applicationUser>
    {
        public AppDpContext(DbContextOptions<AppDpContext> options):base(options)
        {
            
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{

        //    optionsBuilder.UseSqlServer("server=.;database=MVC_43;Trusted_Connection=true;");

        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

           // modelBuilder.ApplyConfiguration<Department>(new DepartmentConfiguration());

            // if you have manu configuration

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


            // if you have fluen api in base  i found if you add security Module
            base.OnModelCreating(modelBuilder);

            // to change table Name IdenityUser ,IdentityRoles

            modelBuilder.Entity<IdentityUser>().ToTable("User");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");

        }

        // Bd set to convert proprty to table in database

        public DbSet<Department> Departments { get; set; }  //Departments  table


        public DbSet<Employee> Employeee { get; set; }//  Employees table


        // Security Domain Models

        //public DbSet<IdentityUser> Users { get; set; }

        //public DbSet<IdentityRole>Roles { get; set; }   
    }
}
