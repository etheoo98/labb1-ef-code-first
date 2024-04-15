using EntityFrameworkCodeFirst.Data;
using EntityFrameworkCodeFirst.Models.DatabaseModels;
using EntityFrameworkCodeFirst.Models.DTOs;
using EntityFrameworkCodeFirst.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCodeFirst.Services;

public class SignedInService(ApplicationDbContext context)
{
    // Todo: Handle null cases for GetLeaveApplicationReasons()
    // Retrieves the entire table of leave application reasons from db
    public List<LeaveApplicationReason> GetLeaveApplicationReasons() => context.LeaveApplicationsReasons.ToList();

    // Creates and fills in the properties of a new LeaveApplication object, before inserting it into db
    public bool SubmitLeaveApplication(LeaveApplicationViewModel viewModel, UserDto userDto)
    {
        var leaveApplication = new LeaveApplication
        {
            CreationDate = DateTime.Now,
            StartDate = viewModel.StartDate,
            EndDate = viewModel.EndDate,
            Note = viewModel.Note,
            EmployeeId = userDto.EmployeeId,
            LeaveApplicationReasonId = viewModel.LeaveApplicationReasonId
        };

        context.LeaveApplications.Add(leaveApplication);
        context.SaveChanges();

        return true;
    }

    // Todo: Handle null cases for GetUserLeaveApplications()
    // Get the leave applications for the provided employee id. It includes relevant data through navigational properties
    // and makes a list of LeaveApplicationDtos where these properties are mapped to.
    public List<LeaveApplicationDto> GetUserLeaveApplications(int employeeId)
    {
        var leaveApplications = context.LeaveApplications
            .Include(u => u.LeaveApplicationReason)
            .Include(u => u.Employee)
            .Where(u => u.EmployeeId == employeeId)
            .OrderBy(u => u.StartDate)
            .Select(l => new LeaveApplicationDto
            (
                $"{l.Employee.FirstName} {l.Employee.LastName}", 
                l.LeaveApplicationReason.Reason,
                l.StartDate,
                l.EndDate,
                l.Note,
                l.CreationDate
            ))
            .ToList();

        return leaveApplications;
    }

    // Todo: Handle null cases for GetAllLeaveApplications()
    public List<LeaveApplicationDto> GetAllLeaveApplications()
    {
        var leaveApplications = context.LeaveApplications
            .Include(u => u.LeaveApplicationReason)
            .Include(u => u.Employee)
            .OrderBy(u => u.StartDate)
            .Select(l => new LeaveApplicationDto
            (
                $"{l.Employee.FirstName} {l.Employee.LastName}", 
                l.LeaveApplicationReason.Reason,
                l.StartDate,
                l.EndDate,
                l.Note,
                l.CreationDate
            ))
            .ToList();

        return leaveApplications;
    }

    // Todo: Handle null cases for GetLeaveApplicationsFromRange()
    // This doesn't throw an exception when the result is null, but something should probably be done differently when the
    // date range doesn't provide a sufficient result.
    public List<LeaveApplicationDto> GetLeaveApplicationsFromRange(LeaveApplicationRangeViewModel viewModel)
    {
        var leaveApplications = context.LeaveApplications.Include(u => u.LeaveApplicationReason)
            .Include(u => u.Employee)
            .Where(u => u.StartDate >= viewModel.StartDate && u.EndDate <= viewModel.EndDate)
            .OrderBy(u => u.StartDate)
            .Select(l => new LeaveApplicationDto
            (
                $"{l.Employee.FirstName} {l.Employee.LastName}", 
                l.LeaveApplicationReason.Reason,
                l.StartDate,
                l.EndDate,
                l.Note,
                l.CreationDate
            ))
            .ToList();

        return leaveApplications;
    }
}