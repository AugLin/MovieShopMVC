using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class MovieGenre
    {
        [Required]
        public int GenreId { get; set; }

        [Required] 
        public int MovieId { get; set; }

        public Movie Movie { get; set; }
        public Genre Genre { get; set; }
    }
}
