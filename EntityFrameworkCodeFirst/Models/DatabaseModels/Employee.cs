using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkCodeFirst.Models.DatabaseModels;

public class Employee
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string FirstName { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string LastName { get; set; }
    
    // Optional one-to-one relationship with User
    public virtual User User { get; set; }
    
    // Optional one-to-many relationship to LeaveApplications
    public ICollection<LeaveApplication>? LeaveApplications { get; set; }
}