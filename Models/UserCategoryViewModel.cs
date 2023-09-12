using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class UserCategoryViewModel
    {
        
        
        [Key]
        public string UserEmail { get; set; }
        public Category ChosenCategory { get; set; }
    }
}