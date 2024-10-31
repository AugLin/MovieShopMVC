using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class User
    {
        [Required]
        public int Id { get; set; }
    
        public DateTime DateOfBirth { get; set; }

        [Required (ErrorMessage = "Email is required")]
        [Column(TypeName = "VARCHAR(256)")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [Column(TypeName = "VARCHAR(128)")]
        public string? FirstName{ get; set; }

        [Required(ErrorMessage = "Password is required")]
        [Column(TypeName = "VARCHAR(1024)")]
        public string? HashedPassword { get; set; }

        public int IsLocked { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [Column(TypeName = "VARCHAR(128)")]
        public string? LastName { get; set; }

        [Column(TypeName = "VARCHAR(16)")]
        public string? PhoneNumber { get; set; }

        [Column(TypeName = "VARCHAR(MAX)")]
        public string? ProfilePictureUrl { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(1024)")]
        public string? Salt {  get; set; }

        public ICollection<Favorite>? Favorites { get; set; }
        public ICollection<Purchase>? Purchases { get; set; }
        public ICollection<Review>? Reviews { get; set; }
        public ICollection<UserRole>? Roles { get; set; }
    }
}
