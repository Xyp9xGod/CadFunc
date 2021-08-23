using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CadFunc.Application.DTOs
{
    public class EmployeeDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Last Name is Required")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The Email is Required")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("E-mail")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid format Email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The Badge is Required")]
        [DisplayName("Badge")]
        public int Badge { get; set; }

        [Required(ErrorMessage = "The Password is Required")]
        [DisplayName("Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "The Phone is Required")]
        [DisplayName("Phone")]
        [MaxLength(11)]
        public string Phone { get; set; }
    }
}
