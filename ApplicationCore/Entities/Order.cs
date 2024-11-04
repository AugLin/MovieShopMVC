using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Order
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public DateTime Order_Date { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(2084)")]
        public string CustomerName { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(2084)")]
        public string PaymentMethod { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(2084)")]
        public string PaymentName { get; set; }
        
        [Required]
        [Column(TypeName = "VARCHAR(2084)")]
        public string ShippingAddress { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(2084)")]
        public string ShippingMethod { get; set; }

        [Required]
        [Column(TypeName = "DECIMAL(5,2)")]
        public decimal BillAmount  { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(2084)")]
        public string Order_Status { get; set; }

        public IEnumerable<Order_Detail> Order_Detail { get; set; }
    }
}
