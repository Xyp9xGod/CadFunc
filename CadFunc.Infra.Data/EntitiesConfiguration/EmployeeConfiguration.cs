using CadFunc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CadFunc.Infra.Data.EntitiesConfiguration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
            builder.Property(p => p.LastName).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Phone).HasMaxLength(11).IsRequired();
            builder.Property(p => p.Badge).HasMaxLength(10).IsRequired();
            builder.HasData(
                new Employee(1, "Employee Name 1", "Employee Last Name", "email1@zup.com.br", 999000, "V02zy9YLAaJxk3au/LqxGw==", "47999998888"),
                new Employee(2, "Employee Name 2", "Employee Last Name", "email2@zup.com.br", 888000, "V02zy9YLAaJxk3au/LqxGw==", "47977778888"),
                new Employee(3, "Employee Name 3", "Employee Last Name", "email3@zup.com.br", 777000, "V02zy9YLAaJxk3au/LqxGw==", "47966668888")
            );
        }
    }
}
