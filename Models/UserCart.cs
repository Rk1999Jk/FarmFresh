using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class UserCart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CartId { get; set; }
        [Display(Name = "Product Id")]
        public int ProductId { get; set; }
        [Display(Name ="User Id")]
        public int UserId { get; set; }
        [Display(Name = "Item Name")]
        public string ItemName { get; set; }
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }
        [Display(Name = "Rate Per Kg")]
        public double RatePerKg { get; set; }
        [Display(Name = "Amount")]
        public double Amount { get; set; }
        [Display(Name ="Farmer Email")]
        public string FarmerEmail { get; set; }
    }
}