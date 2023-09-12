using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class UserQuantitySelectionModel
    {
        public int CartId { get; set; }
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }
    }
}