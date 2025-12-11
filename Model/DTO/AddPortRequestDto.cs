using System.ComponentModel.DataAnnotations;

namespace AirlineManagement.Model.DTO
{
    public class AddPortRequestDto
    {
        [Required]
        public required string Name { get; set; }

        [Required]
        [MaxLength(5, ErrorMessage = "Code must Not Be More that 5 Letters")]
        public required string Code { get; set; }

        [Required]
        public required string City { get; set; }

        [Required]
        public required string Country { get; set; }
    }
}
