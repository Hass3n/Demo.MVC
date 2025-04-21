using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DAL.Models.EmployeeDepartment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo.DAL.Data.Configuration
{
    public class EmployeeConfiguration : BaseEntityConfiguration<Employee>,IEntityTypeConfiguration<Employee>
    {
        public new  void Configure(EntityTypeBuilder<Employee> builder)
        {

            builder.Property(E => E.Name).HasColumnType("varchar(50)");
            builder.Property(E => E.Address).HasColumnType("varchar(150)");
            builder.Property(E => E.Salary).HasColumnType("decimal(10,2)");

            // هنا أنا بخزن النوع كاسم ميل أو فيميل في الداتا بيز مش هخزن قيم أرقام هو راجع محتاج أرقام عشان كده عملت التحويل 

            builder.Property(E => E.gander)
                .HasConversion((empGender) => empGender.ToString(),
                (returnEmpGander) => (Gander)Enum.Parse(typeof(Gander), returnEmpGander)



                );

            builder.Property(E => E.employeeType)
            .HasConversion((empType) => empType.ToString(),
            (returnEmptype) => (EmployeeType)Enum.Parse(typeof(EmployeeType), returnEmptype)



            );


            // call method in  BaseEntityConfiguration
            base.Configure(builder);



        }
    }
}
