using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class UserRole
    {
        [Required]
        public int RoleId { get; set; }

        [Required]
        public int UserId { get; set; }

        public Role Role { get; set; }
        public User User { get; set; }

    }
}
