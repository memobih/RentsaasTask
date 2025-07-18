using System.ComponentModel.DataAnnotations;

namespace RentsaasTask.DataTransferObjects
{
    public class EmployeeDto
    {

        [Required(ErrorMessage = "this field is required")]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "this field is required")]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "this field is required")]
        [EmailAddress(ErrorMessage = "this is uncorrect email format")]
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "this field is required")]
        [StringLength(100)]
        public string Position { get; set; } = string.Empty;
    }
}
