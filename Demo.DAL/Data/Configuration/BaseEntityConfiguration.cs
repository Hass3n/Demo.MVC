using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo.DAL.Data.Configuration
{

    //ليه خليتها جنارك عشان خاطر كده انا مش هعملها معامله جدول في الداتا بيز
    public class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            //  HasDefaultValueSql("GETDATE()")  دي تخزن التاريخ اول مره انا بعمل انشاء للجدول ومش بيتغير 
            builder.Property(D => D.CreatedOn).HasDefaultValueSql("GETDATE()");

            //HasComputedColumnSql("GETDATE()")  دي تخزن التاريخ في الداتا بيز وبيتغير مع كل اوبرشن انا بعملها علي الجدول
            builder.Property(D => D.LastModifiedOn).HasComputedColumnSql("GETDATE()");
        }
    }
}
