using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Review
    {
        [Required]
        public int MovieId { get; set; }
        
        [Required]
        public int UserId { get; set; }
        
        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        [Column(TypeName = "DECIMAL(3,2)")]
        public decimal Rating { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(MAX)")]
        public string? ReviewText { get; set; }

        public Movie Movie { get; set; }
        public User User { get; set; }
    }
}
