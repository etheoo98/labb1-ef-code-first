namespace EntityFrameworkCodeFirst.Models.DTOs;

public class UserDto(int userId, int employeeId, string role)
{
    public int UserId { get; set; } = userId;
    public int EmployeeId { get; set; } = employeeId;
    public string Role { get; set; } = role;
}