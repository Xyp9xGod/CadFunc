using CadFunc.Domain.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CadFunc.Application.DTOs
{
    public class PhoneDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The Phone is Required")]
        [DisplayName("Phone Number")]
        [MaxLength(11)]
        public string Number { get; set; }
        public int EmployeeId { get; set; }

        [JsonIgnore]
        public Employee Employee { get; set; }
    }
}
