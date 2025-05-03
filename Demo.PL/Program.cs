using System;
using Demo.BLL.Profiles;
using Demo.BLL.Services.AttatchmentServices;
using Demo.BLL.Services.Classes;
using Demo.BLL.Services.Interface;
using Demo.DAL.Data;
using Demo.DAL.Data.Repositries.Classes;
using Demo.DAL.Data.Repositries.interfcae;
using Demo.DAL.Models;
using Microsoft.AspNetCore.Identity;
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
                // lazy loading to load Related Data from Many tables
                options.UseLazyLoadingProxies();
            });


            // when clr create object IDepartmentRepostry create object for DepartmentRepostry

            builder.Services.AddScoped<IDepartmentRepostry,DepartmentRepostry>();


            builder.Services.AddScoped<IDepartmentServices, DepartmentServices>();

            builder.Services.AddScoped<IEmployeeRepositry, EmployeeRepsoitry>();

            builder.Services.AddScoped<IEmployeeServices, EmployeeServices>();
            builder.Services.AddScoped<InUnitOfWork, UnitofWork>();
            builder.Services.AddScoped<IAttatchmantServices, AttatchmentServices>();

            //  بس الطريقه دي ساعات بتضرب ايرور  Mapper يعمل اوبجكت من clr عشان ال

            //builder.Services.AddAutoMapper(typeof(MappingProfiles).Assembly);

            // (DI) Mapper يعمل اوبجكت من clr الطريقه الثانيه تطلب فيها من
            builder.Services.AddAutoMapper(M => M.AddProfile(new MappingProfiles()));


            // add services for security first way
            //builder.Services.AddScoped < UserManager<applicationUser>>();
            //builder.Services.AddScoped<SignInManager<applicationUser>>();
            //builder.Services.AddScoped<RoleManager<IdentityRole>>();


            // add services for security second way

            builder.Services.AddIdentity<applicationUser, IdentityRole>(

                option =>
                {

                    // كده المستخدم لازم يدخل أيميل يكون مش مستخدم قبل كده
                    //option.User.RequireUniqueEmail = true;


                }



                // register store Repositry to Enable used Method inside this like servieces call Method iside Respositry
                ).AddEntityFrameworkStores<AppDpContext>().AddDefaultTokenProviders();


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

            // Two Middle ware to eanble user Login and use action based on Roles
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Account}/{action=Register}/{id?}");

            app.Run();
        }
    }
}
