using CadFunc.Domain.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CadFunc.Domain.Tests
{
    public class EmployeeUnitTest
    {
        [Fact]
        public void CreateEmployee_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Employee(1, "Employee Name", "Employee Last Name", "email@zup.com.br", 999000, "password");
            action.Should()
                .NotThrow<Validations.DomainExceptionValidation>();
        }
        [Fact]
        public void CreateEmployee_WithoutId_ResultObjectValidState()
        {
            Action action = () => new Employee("Employee Name", "Employee Last Name", "email@zup.com.br", 999000, "password");
            action.Should()
                .NotThrow<Validations.DomainExceptionValidation>();
        }
        [Fact]
        public void CreateEmployee_WithoutName_ResultObjectValidState()
        {
            Action action = () => new Employee("", "Employee Last Name", "email@zup.com.br", 999000, "password");
            action.Should()
                .Throw<Validations.DomainExceptionValidation>()
                .WithMessage("Invalid name, Name is required.");
        }
        [Fact]
        public void CreateEmployee_WithoutLastName_ResultObjectValidState()
        {
            Action action = () => new Employee("Teste", "", "email@zup.com.br", 999000, "password");
            action.Should()
                .Throw<Validations.DomainExceptionValidation>()
                .WithMessage("Invalid Last Name, Last Name is required.");
        }
        [Fact]
        public void CreateEmployee_WithoutEmail_ResultObjectValidState()
        {
            Action action = () => new Employee("Teste", "Employee Last Name", "", 999000, "password");
            action.Should()
                .Throw<Validations.DomainExceptionValidation>()
                .WithMessage("Invalid email, Email is required.");
        }
        [Fact]
        public void CreateEmployee_WithInvalidBadge_ResultObjectValidState()
        {
            Action action = () => new Employee("Teste", "Employee Last Name", "email@zup.com.br", -8, "password");
            action.Should()
                .Throw<Validations.DomainExceptionValidation>()
                .WithMessage("Invalid Badge value.");
        }
        [Fact]
        public void CreateEmployee_WithoutPassword_ResultObjectValidState()
        {
            Action action = () => new Employee("Teste", "Employee Last Name", "email@zup.com.br", 999000, "");
            action.Should()
                .Throw<Validations.DomainExceptionValidation>()
                .WithMessage("Invalid password, Password is required.");
        }
    }
}
