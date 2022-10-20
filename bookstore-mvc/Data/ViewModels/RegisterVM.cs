using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bookstore_mvc.Data.ViewModels
{
  public class RegisterVM
  {
    [Display(Name = "Full Name")]
    [Required(ErrorMessage = "Full name is required")]
    public string FullName { get; set; } = string.Empty;

    [Display(Name = "Email address")]
    [Required(ErrorMessage = "Email address is required")]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Display(Name = "Password")]
    [Required(ErrorMessage = "Password is required")]
    [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;

    [Display(Name = "Confirm Password")]
    [Required(ErrorMessage = "Confirm password is required")]
    [Compare("Password", ErrorMessage = "Passwords must match!")]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; } = string.Empty;
  }
}