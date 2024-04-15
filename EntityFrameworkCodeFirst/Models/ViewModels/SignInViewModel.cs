using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkCodeFirst.Models.ViewModels;

public class SignInViewModel
{
    [Required(ErrorMessage = "Missing Email Address")]
    [EmailAddress(ErrorMessage = "Invalid Email Format")]
    [Display(Name = "Email Address")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "Missing Password")]
    [Display(Name = "Password")]
    public string Password { get; set; }
}