using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NETCoreAPI.Models.Config
{
    public class BusinessUnitConfig : IEntityTypeConfiguration<BusinessUnit>
    {
        public void Configure(EntityTypeBuilder<BusinessUnit> builder)
        {
            builder.HasKey(m => m.Id);


            builder.Property(m => m.Name)
                .IsRequired()
                .IsUnicode(false)
                .HasMaxLength(50);

            builder.Property(m => m.CreatedAt)
            .HasColumnType("DateTime")
            .HasComputedColumnSql("GetDate()");


            builder.HasOne(m => m.Department)
                .WithMany(m => m.BusinessUnits);
        }
    }
}
