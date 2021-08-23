using CadFunc.Domain.Validations;

namespace CadFunc.Domain.Entities
{
    public class Employee : Entity
    {
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public int Badge { get; private set; }
        public string Password { get; private set; }
        public string Phone { get; private set; }

        public Employee(string name, string lastName, string email, int badge, string password, string phone)
        {
            ValidateDomain(name, lastName, email, badge, password, phone);
        }

        public Employee(int id, string name, string lastName, string email, int badge, string password, string phone)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value.");
            Id = id;
            ValidateDomain(name, lastName, email, badge, password, phone);
        }

        public void Update(string name, string lastName, string email, int badge, string password, string phone)
        {
            ValidateDomain(name, lastName, email, badge, password, phone);
        }

        private void ValidateDomain(string name, string lastName, string email, int badge, string password, string phone)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name, Name is required.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(lastName), "Invalid Last Name, Last Name is required.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(email), "Invalid Email, Email is required.");
            DomainExceptionValidation.When(badge < 0, "Invalid Badge value.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(password), "Invalid Password, Password is required.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(phone), "Invalid Phone, Password is required.");

            Name = name;
            LastName = lastName;
            Email = email;
            Badge = badge;
            Password = password;
            Phone = phone;
        }
    }
}
