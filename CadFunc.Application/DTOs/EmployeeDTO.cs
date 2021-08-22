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
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The Badge is Required")]
        public int Badge { get; set; }
        public string Password { get; set; }
    }
}
