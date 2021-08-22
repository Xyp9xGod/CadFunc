using CadFunc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadFunc.Infra.Data.EntitiesConfiguration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
            builder.Property(p => p.LastName).HasMaxLength(100).IsRequired();

            //Implementar o telefone poderá ter mais de um.

            //builder.Property(p => p.Price).HasPrecision(10, 2);
            //builder.HasOne(e => e.Category).WithMany(e => e.Products)
            //    .HasForeignKey(e => e.CategoryId);
            //insere dados na hora da criação
            builder.HasData(
                new Employee(1, "Employee Name 1", "Employee Last Name", "email1@zup.com.br", 999000, "password"),
                new Employee(2, "Employee Name 2", "Employee Last Name", "email2@zup.com.br", 888000, "password"),
                new Employee(3, "Employee Name 3", "Employee Last Name", "email3@zup.com.br", 777000, "password")
            );
        }
    }
}
