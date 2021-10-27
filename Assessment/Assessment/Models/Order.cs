using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assessment.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public string OrderNumber { get; set; }
        [Required]
        public float Amount { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string OrderDate { get; set; } 
        [Required]
        public string OrderStatus { get; set; }

    }
}
