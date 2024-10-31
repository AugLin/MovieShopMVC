using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Movie
    {
        public int Id { get; set; }

        [Column(TypeName = "VARCHAR(2084)")]
        public string? BackdropUrl { get; set; }

        [Column(TypeName = "DECIMAL(18,4)")]
        public decimal? Budget {  get; set; }

        [Column(TypeName = "VARCHAR(MAX)")]
        public string? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }
        
        [Column(TypeName = "VARCHAR(2084)")] 
        public string? ImdbUrl { get; set; }

        [Column(TypeName = "VARCHAR(64)")] 
        public string? OriginalLanguage { get; set; }

        [Column(TypeName = "VARCHAR(MAX)")] 
        public string? Overview {  get; set; }

        [Column(TypeName = "VARCHAR(2084)")] 
        public string? PosterUrl { get; set; }

        [Column(TypeName = "DECIMAL(5,2)")]

        public decimal? Price { get; set; }

        public DateTime ReleaseDate { get; set; }

        [Column(TypeName = "DECIMAL(18,4)")]
        public decimal? Revenue { get; set; }

        public int? Runtime {  get; set; }

        [Column(TypeName = "VARCHAR(512)")] 
        public string? Tagline { get; set; }

        [Column(TypeName = "VARCHAR(256)")] 
        public string? Title { get; set; }

        [Column(TypeName = "VARCHAR(2084)")] 
        public string? TmdbUrl { get; set; }

        [Column(TypeName = "VARCHAR(MAX)")] 
        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public ICollection<Trailer> Trailers { get; set; }
        public ICollection<MovieCast> Casts { get; set; }
        public ICollection<MovieGenre> Genres { get; set; }
    }
}
