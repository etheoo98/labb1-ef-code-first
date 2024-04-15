using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkCodeFirst.Models.DatabaseModels;

public class LeaveApplicationReason
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public string Reason { get; set; }
}