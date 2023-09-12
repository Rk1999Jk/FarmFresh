using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class CategoryTable
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
            
    }
}