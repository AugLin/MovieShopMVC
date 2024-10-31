using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Models
{

    public class UserRegisterRequestModel
    {
        [Required(ErrorMessage = "Firstname address can not be empty!")]
        [StringLength(100)]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "Lastname address can not be empty!")]
        [StringLength(100)]
        public string Lastname { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Email address can not be empty!")]
        [EmailAddress(ErrorMessage = "Email address should be in right format!")]
        [StringLength(100)]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }

    }


}

