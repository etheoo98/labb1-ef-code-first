using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkCodeFirst.Models.ViewModels;

public class LeaveApplicationViewModel
{
    // TODO: Output the error messages when the view model is invalid
    [Required(ErrorMessage = "Missing Start Date")]
    [Display(Name = "Start Date")]
    public DateTime StartDate { get; set; }
    
    [Required(ErrorMessage = "Missing End Date")]
    [Display(Name = "End Date")]
    public DateTime EndDate { get; set; }
    
    [Display(Name = "Note")]
    public string? Note { get; set; }
    
    [Required(ErrorMessage = "Missing Reason")]
    public int LeaveApplicationReasonId { get; set; }
}