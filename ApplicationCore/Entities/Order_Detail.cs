using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Order_Detail
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        public int OrderId { get; set; }
       
        [Required]
        public int ProductId { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(2084)")]
        public string ProductName { get; set; }
        
        [Required]
        public int Quantity { get; set; }

        [Required]
        [Column(TypeName = "DECIMAL(5,2)")]
        public decimal Price { get; set; }

        [Required]
        [Column(TypeName = "DECIMAL(3,2)")]
        public decimal Discount { get; set; }
    }
}
