using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Trailer
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int MovieId { get; set; }
        
        [Required]
        [Column(TypeName = "VARCHAR(2084)")]
        public string Name { get; set; }
        
        [Required]
        [Column(TypeName = "VARCHAR(2084)")]
        public string? TrailerUrl { get; set; }

        public Movie Movie { get; set; }

    }
}
