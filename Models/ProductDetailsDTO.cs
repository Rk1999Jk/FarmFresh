using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class ProductDetailsDTO
    {
        public int ProductId { get; internal set; }
        public Category ProductCategory { get; internal set; }
        public string ItemName { get; internal set; }
        public int QuantityInStock { get; internal set; }
        public double RatePerKg { get; internal set; }
        public DateTime DateOfHarvest { get; internal set; }
        public float FreshRating { get; internal set; }
        public string PFarmerEmail { get; internal set; }
    }
}