using System;
using System.ComponentModel.DataAnnotations;

namespace IdentityProvider.Models
{
    public class ForgotPasswordModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
