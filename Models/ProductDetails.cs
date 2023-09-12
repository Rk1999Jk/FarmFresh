using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class ProductDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        [Required]
        [Display(Name = "Category")]
        public  Category ProductCategory { get; set; }
        [Required]
        [Display(Name = "Item Name")]
        //[RegularExpression(@"[a-z][A-Z]+$", ErrorMessage = "Item Name should only contain alphabets")]
        public string ItemName { get; set; }
        [Required]
        [Display(Name ="Quantity In Stock")]
        public int QuantityInStock { get; set; }
        [Required]
        [RegularExpression(@"\d+(\.\d+)?$", ErrorMessage = "Item Name should only contain alphabets")]
        [Display(Name ="Rate per KG")]
        public double RatePerKg { get; set; }
        [Required]
        [Display(Name ="Date Of Harvest")]
        public DateTime DateOfHarvest { get; set; }
        public string PFarmerEmail { get; set; }
        public float FreshRating { get; set; }
    }
    public enum Category
    {
        
        Vegetables,
        Fruits,
        Herbs,
        Grains,
        Greens,
        Honey
    }
}