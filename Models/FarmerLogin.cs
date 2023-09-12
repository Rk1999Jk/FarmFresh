using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class FarmerLogin
    {
        [Required]
        [Key]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string FarmersLoginEmail { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="Password")]
        public string FarmersLoginPassword { get; set; }
    }
}