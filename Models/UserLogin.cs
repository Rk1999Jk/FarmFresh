using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class UserLogin
    {
        [Required]
        [Key]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        public string UserEmail { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }
    }
}