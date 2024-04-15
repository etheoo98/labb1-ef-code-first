using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkCodeFirst.Models.DatabaseModels;

public class LeaveApplication
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public DateTime StartDate { get; set; }
    
    [Required]
    public DateTime EndDate { get; set; }
    
    public string? Note { get; set; }
    
    [Required]
    public DateTime CreationDate { get; set; }
    
    // Required many-to-one relationship with Employee
    [Required]
    [ForeignKey("Employee")]
    public int EmployeeId { get; set; }
    
    // Navigation property
    [Required]
    public virtual Employee Employee { get; set; }
    
    [Required]
    [ForeignKey("LeaveApplicationReason")]
    public int LeaveApplicationReasonId { get; set; }
    
    // Navigation property
    public virtual LeaveApplicationReason LeaveApplicationReason { get; set; }
}