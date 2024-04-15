using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkCodeFirst.Models.DatabaseModels;

public class UserRole
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 1)]
    public string Role { get; set; }
}