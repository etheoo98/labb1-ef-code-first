using EntityFrameworkCodeFirst.Data;
using EntityFrameworkCodeFirst.Models.DTOs;
using EntityFrameworkCodeFirst.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCodeFirst.Services;

public class HomeService(ApplicationDbContext context)
{
    // Queries db using the credentials provided by the sign-in view to retrieve the relevant User object
    // (if any) and its associated UserRole object. The IDs and Role is returned as a User DTO.
    public UserDto? AttemptSignIn(SignInViewModel signInUser)
    {
        var foundUser = context.Users
            .Include(u => u.Employee)
            .Include(u => u.UserRole)
            .FirstOrDefault(u => u.Email == signInUser.Email
                                 && u.Password == signInUser.Password);
        
        // Return null if no user is found
        return foundUser == null ? null : new UserDto(foundUser.Id, foundUser.EmployeeId, foundUser.UserRole.Role);
    }
}