using System.Diagnostics;
using EntityFrameworkCodeFirst.Models.ViewModels;
using EntityFrameworkCodeFirst.Services;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkCodeFirst.Controllers;

public class HomeController(HomeService homeService) : Controller
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    public IActionResult Index() => View();
    
    public IActionResult SignIn() => View();
    
    // Validate that the user credentials are correct before setting session data and redirecting
    [HttpPost]
    public IActionResult SignIn(SignInViewModel viewModel)
    {
        if (!ModelState.IsValid) return View(viewModel);

        var userDto = homeService.AttemptSignIn(viewModel);

        if (userDto == null) return View(viewModel);
        
        // Set session variables
        HttpContext.Session.SetInt32("user-id", userDto.UserId);
        HttpContext.Session.SetInt32("employee-id", userDto.EmployeeId);
        HttpContext.Session.SetString("role", userDto.Role);
        
        return RedirectToAction("Index", "SignedIn");

    }
}