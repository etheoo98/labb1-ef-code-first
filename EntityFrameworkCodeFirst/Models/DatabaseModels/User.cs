using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkCodeFirst.Models.DatabaseModels;

public class User
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [StringLength(100)]
    public string Email { get; set; }
    
    [Required]
    [StringLength(100)]
    public string Password { get; set; }
    
    [ForeignKey("Employee")]
    public int EmployeeId { get; set; }
    public virtual Employee Employee { get; set; }
    
    [ForeignKey("UserRole")]
    public int UserRoleId { get; set; }
    public virtual UserRole UserRole { get; set; }
}