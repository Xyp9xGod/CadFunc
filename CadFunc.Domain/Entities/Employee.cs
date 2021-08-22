using CadFunc.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadFunc.Domain.Entities
{
    public sealed class Employee : Entity
    {
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public int Badge { get; private set; }
        public string Password { get; private set; }

        public Employee(string name, string lastName, string email, int badge, string password)
        {
            ValidateDomain(name, lastName, email, badge, password);
        }

        public Employee(int id, string name, string lastName, string email, int badge, string password)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value.");
            Id = id;
            ValidateDomain(name, lastName, email, badge, password);
        }

        public void Update(string name, string lastName, string email, int badge, string password)
        {
            ValidateDomain(name, lastName, email, badge, password);
            //atualizar o PhoneId???
        }

        private void ValidateDomain(string name, string lastName, string email, int badge, string password)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name, Name is required.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(lastName), "Invalid Last Name, Last Name is required.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(email), "Invalid email, Email is required.");
            DomainExceptionValidation.When(badge < 0, "Invalid Badge value.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(password), "Invalid password, Password is required.");

            Name = name;
            LastName = lastName;
            Email = email;
            Badge = badge;
            Password = password;
        }
    }
}
