using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class FarmerDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FarmerId { get; set; }
        [Required]
        [Display(Name = "Farmer's Name")]
        public string FarmersName { get; set; }
        [Required]
        [Display(Name = "Mobile Number")]
        [RegularExpression(@"[1-9]{1}[0-9]{9}$", ErrorMessage = "Invalid Mobile Number")]
        public long FarmersMobileNumber { get; set; }
        [Display(Name = "Farms Address")]
        public string FarmsAddress { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string FarmersEmail { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string FPassword { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string FConfirmPassword { get; set; }

    }
}