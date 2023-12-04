using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Identity;
using HR.LeaveManagement.Application.Models.Identity;
using HR.LeaveManagement.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace HR.LeaveManagement.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<List<Employee>> EmployeeListAsync()
        {
            var employees = await _userManager.GetUsersInRoleAsync("Employee");

            return employees.Select(x => new Employee
            {
                Id = x.Id,
                Email = x.Email,
                FirstName = x.FirstName,
                LastName = x.LastName,
            }).ToList();
        }

        public async Task<Employee> GetEmployeeDetailAsync(string userId)
        {
            var findEmployeeById=await _userManager.FindByIdAsync(userId);

            return new Employee
            {
                Id = findEmployeeById.Id,
                Email = findEmployeeById.Email,
                FirstName = findEmployeeById.FirstName,
                LastName = findEmployeeById.LastName,
            };
        }
    }
}
