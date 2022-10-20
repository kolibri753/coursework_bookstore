using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace bookstore_mvc.Models
{
  public class ApplicationUser : IdentityUser
  {
    [Required(ErrorMessage = "Full name is required")]
    [Display(Name = "Full name")]
    public string FullName { get; set; } = string.Empty;

    // [Required(ErrorMessage = "Phone number is required")]
    // [Display(Name = "Phone number")]
    // [DataType(DataType.PhoneNumber)]
    // public string Phone { get; set; } = string.Empty;

    // [Required(ErrorMessage = "Address is required")]
    // [Display(Name = "Address")]
    // public string Address { get; set; } = string.Empty;
  }
}