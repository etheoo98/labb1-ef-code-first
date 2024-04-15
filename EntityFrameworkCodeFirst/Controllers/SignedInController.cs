using EntityFrameworkCodeFirst.Models.DTOs;
using EntityFrameworkCodeFirst.Models.ViewModels;
using EntityFrameworkCodeFirst.Services;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkCodeFirst.Controllers;

public class SignedInController(ILogger<SignedInController> logger, SignedInService signedInService) : Controller
{
    // Current user
    private UserDto? UserDto { get; set; }

    public IActionResult Index()
    {
        // Redirect to sign-in page if unable to set UserDto
        if (!SetUserDto()) return RedirectToAction("SignIn", "Home");

        return View(UserDto);
    }

    // Clear the cookie containing user data and redirect to Home page
    public new IActionResult SignOut()
    {
        HttpContext.Session.Clear();

        return RedirectToAction("Index", "Home");
    }

    // Get the leave application reasons from db and send them to the view for output
    public IActionResult LeaveApplication()
    {
        if (!SetUserDto()) return RedirectToAction("SignIn", "Home");

        var leaveApplicationReasons = signedInService.GetLeaveApplicationReasons();

        return View(leaveApplicationReasons);
    }

    // Get the user's leave applications from db and send them to the view for output
    public IActionResult UserLeaveApplications()
    {
        if (!SetUserDto()) return RedirectToAction("SignIn", "Home");

        var leaveApplications = signedInService.GetUserLeaveApplications(UserDto!.EmployeeId);

        return View(leaveApplications);
    }

    // Get all leave applications from db and send them to the view for output
    public IActionResult AllLeaveApplications()
    {
        if (!SetUserDto()) return RedirectToAction("SignIn", "Home");

        var leaveApplications = signedInService.GetAllLeaveApplications();

        return View(leaveApplications);
    }

    // Insert the user's leave application data into db and redirect upon success
    [HttpPost]
    public IActionResult LeaveApplication(LeaveApplicationViewModel viewModel)
    {
        if (!SetUserDto()) return RedirectToAction("SignIn", "Home");

        if (!ModelState.IsValid) return RedirectToAction("LeaveApplication", "SignedIn");

        var isSuccessful = signedInService.SubmitLeaveApplication(viewModel, UserDto!);

        if (isSuccessful) return RedirectToAction("UserLeaveApplications");

        throw new NotImplementedException();
    }

    // Get all leave applications based on date range from db and send them to the view for output
    [HttpPost]
    public IActionResult AllLeaveApplications(LeaveApplicationRangeViewModel viewModel)
    {
        if (!SetUserDto()) return RedirectToAction("SignIn", "Home");

        var leaveApplications = signedInService.GetLeaveApplicationsFromRange(viewModel);

        return View(leaveApplications);
    }

    // A terrible way of handling authorization...
    private bool SetUserDto()
    {
        try
        {
            var userId = HttpContext.Session.GetInt32("user-id");
            var employeeId = HttpContext.Session.GetInt32("employee-id");
            var role = HttpContext.Session.GetString("role");

            if (userId == null || employeeId == null || role == null) throw new Exception();

            UserDto = new UserDto(userId.Value, employeeId.Value, role);

            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}