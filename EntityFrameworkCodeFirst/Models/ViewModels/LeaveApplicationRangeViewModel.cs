using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkCodeFirst.Models.ViewModels;

public class LeaveApplicationRangeViewModel
{
    // TODO: Output the error messages when the view model is invalid
    [Display(Name = "Start Date")]
    public DateTime StartDate { get; set; }
    
    [Display(Name = "End Date")]
    public DateTime EndDate { get; set; }
}