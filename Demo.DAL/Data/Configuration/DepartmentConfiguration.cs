using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DAL.Models.DepartmentModel;
using Demo.DAL.Models.EmployeeDepartment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo.DAL.Data.Configuration
{
    class DepartmentConfiguration :BaseEntityConfiguration<Department>, IEntityTypeConfiguration<Department>
    {
        public new void Configure(EntityTypeBuilder<Department> builder)
        {

            builder.Property(D => D.Id).UseIdentityColumn(10, 10);

            builder.Property(D => D.Name).HasColumnType("varchar(20)");
            builder.Property(D => D.Code).HasColumnType("varchar(20)");
            builder.Property(D => D.CreatedOn).HasDefaultValueSql("GETDATE()");
            builder.Property(D => D.LastModifiedOn).HasComputedColumnSql("GETDATE()");
            builder.HasMany(D => D.Employees)
                    .WithOne(e => e.Departments).OnDelete(DeleteBehavior.Cascade);

            // لو مسحت اي قسم يمسح الموظفين المرتطبطين بيه DeleteBehavior.Cascade


            // call method in  BaseEntityConfiguration
            base.Configure(builder);

        }
    }
}
