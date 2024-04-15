using EntityFrameworkCodeFirst.Models.DatabaseModels;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCodeFirst.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<LeaveApplication> LeaveApplications { get; set; }
    public DbSet<LeaveApplicationReason> LeaveApplicationsReasons { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        AddSampleData(modelBuilder);
    }

    private static void AddSampleData(ModelBuilder modelBuilder)
    {
        // Employees Sample Data
        var employees = new List<Employee>
        {
            new() { Id = 1, FirstName = "Johan", LastName = "Edlund" },
            new() { Id = 2, FirstName = "Heikki", LastName = "Wallenberg" },
            new() { Id = 3, FirstName = "Leo", LastName = "Andersson" },
            new() { Id = 4, FirstName = "Ellen", LastName = "Blixt" }
        };

        modelBuilder.Entity<Employee>().HasData(employees);

        // UserRoles Sample Data
        var userRoles = new List<UserRole>
        {
            new() { Id = 1, Role = "Admin" },
            new() { Id = 2, Role = "User" }
        };

        modelBuilder.Entity<UserRole>().HasData(userRoles);

        // Users Sample Data
        var users = new List<User>
        {
            new()
            {
                Id = 1, Email = "a@a.a", Password = "123", EmployeeId = employees[0].Id, UserRoleId = userRoles[0].Id
            },
            new()
            {
                Id = 2, Email = "heikki@gmail.com", Password = "123", EmployeeId = employees[1].Id,
                UserRoleId = userRoles[1].Id
            },
            new()
            {
                Id = 3, Email = "leo@live.com", Password = "123", EmployeeId = employees[2].Id,
                UserRoleId = userRoles[1].Id
            },
            new()
            {
                Id = 4, Email = "ellen@hotmail.com", Password = "123", EmployeeId = employees[3].Id,
                UserRoleId = userRoles[1].Id
            }
        };

        modelBuilder.Entity<User>().HasData(users);

        // LeaveApplicationReasons Sample Data
        var leaveApplicationReasons = new List<LeaveApplicationReason>
        {
            new() { Id = 1, Reason = "Sick Leave" },
            new() { Id = 2, Reason = "Vacation" },
            new() { Id = 3, Reason = "Parental Leave" },
            new() { Id = 4, Reason = "Other" }
        };

        modelBuilder.Entity<LeaveApplicationReason>().HasData(leaveApplicationReasons);

        // LeaveApplications Sample Data
        var leaveApplications = new List<LeaveApplication>
        {
            new()
            {
                Id = 1, EmployeeId = employees[0].Id, StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(28),
                LeaveApplicationReasonId = 2, Note = "I can't take this job anymore. I need a break.",
                CreationDate = DateTime.Now
            },
            new()
            {
                Id = 2, EmployeeId = employees[1].Id, StartDate = DateTime.Now.AddDays(-1),
                EndDate = DateTime.Now.AddDays(1),
                LeaveApplicationReasonId = 3,
                Note = "I need to stay home and care for my sick child for a couple of days.",
                CreationDate = DateTime.Now
            },
            new()
            {
                Id = 3, EmployeeId = employees[2].Id, StartDate = DateTime.Now.AddDays(-7),
                EndDate = DateTime.Now.AddDays(5),
                LeaveApplicationReasonId = 1,
                Note = "I must have caught the flu. I'll be out of commission for a while.", CreationDate = DateTime.Now
            },
            new()
            {
                Id = 4, EmployeeId = employees[3].Id, StartDate = DateTime.Now.AddDays(-3),
                EndDate = DateTime.Now.AddDays(-1),
                LeaveApplicationReasonId = 4, CreationDate = DateTime.Now
            }
        };

        modelBuilder.Entity<LeaveApplication>().HasData(leaveApplications);
    }
}