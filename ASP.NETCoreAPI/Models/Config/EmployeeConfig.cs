using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NETCoreAPI.Models.Config
{
    public class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m=>m.FirstName)
                .IsRequired()
                .IsUnicode(false)
                .HasMaxLength(50);

            builder.Property(m => m.LastName)
                .IsRequired()
                .IsUnicode(false)
                .HasMaxLength(50);

           
                builder.Property(m => m.DateOfBirth)
                .IsRequired()
                .HasColumnType("DateTime")
                .HasComputedColumnSql("GetDate()");

            builder.Property(m => m.CreatedAt)
            .HasColumnType("DateTime")
            .HasComputedColumnSql("GetDate()");

           //Navigational Reference setup for Employees and BusinessUnit
            builder.HasOne(m=>m.BusinessUnit)
                .WithMany(m=>m.Employees);
               


        }
    }
}
