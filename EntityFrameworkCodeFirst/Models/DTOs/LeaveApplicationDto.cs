namespace EntityFrameworkCodeFirst.Models.DTOs;

public class LeaveApplicationDto(string employeeName, string leaveApplicationReason, DateTime startDate, DateTime endDate, string? note, DateTime creationDate)
{
    public string EmployeeName { get; set; } = employeeName;
    public string LeaveApplicationReason { get; set; } = leaveApplicationReason;
    public DateTime StartDate { get; set; } = startDate;
    public DateTime EndDate { get; set; } = endDate;
    public string? Note { get; set; } = note;
    public DateTime CreationDate { get; set; } = creationDate;
}