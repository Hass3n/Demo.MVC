using System;
using Demo.BLL.Services;
using Demo.DAL.Data;
using Demo.DAL.Data.Repositries.Classes;
using Demo.DAL.Data.Repositries.interfcae;
using Microsoft.EntityFrameworkCore;

namespace Demo.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            #region Cofigure services (Dependency Injection)

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            /*   builder.Services.AddScoped<AppDpContext>();*/ // Allow DI for  AppDpContext

            // add register services for  dbContextoption and dbContext

            builder.Services.AddDbContext<AppDpContext>(options =>
            {

                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnections"));
            });


            // when clr create object IDepartmentRepostry create object for DepartmentRepostry

            builder.Services.AddScoped<IDepartmentRepostry,DepartmentRepostry>();


            builder.Services.AddScoped<IDepartmentServices, DepartmentServices>();

            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
