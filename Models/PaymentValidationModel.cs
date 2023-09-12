using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class PaymentValidationModel
    {
        [Required]
        public string CardHolderName { get; set; }
        [Required]
        [StringLength(3, ErrorMessage = "Invalid CVV", MinimumLength = 3)]
        [DataType(DataType.Password)]
        public string Cvv { get; set; }
        [Required]
        [StringLength(16, ErrorMessage = "Invalid Card Number", MinimumLength =16)]
        public string CardNumber { get; set; }

    }
}