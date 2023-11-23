using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Contracts.Persistence;

public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
{
    Task<LeaveRequest> GetLeaveRequestWithDetailsByIdAsync(int id);
    Task<List<LeaveRequest>> GetLeaveRequestListWithDetailsAsync();
    Task<List<LeaveRequest>> GetLeaveRequestListWithDetailsByUserIdAsync(string userId);
}