using HR.LeaveManagement.Application.Models.Identity;

namespace HR.LeaveManagement.Application.Identity
{
    public interface IUserService
    {
        Task<List<Employee>> EmployeeListAsync();
        Task<Employee> GetEmployeeDetailAsync(string userId);
    }
}
