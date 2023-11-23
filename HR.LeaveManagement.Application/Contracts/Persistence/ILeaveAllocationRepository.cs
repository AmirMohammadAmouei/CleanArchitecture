using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Contracts.Persistence;

public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
{
  
        Task<LeaveAllocation> GetLeaveAllocationDetailsByIdAsync(int id);
        Task<List<LeaveAllocation>> GetLeaveAllocationListWithDetailsAsync();
        Task<List<LeaveAllocation>> GetLeaveAllocationListWithDetailsByUserIdAsync(string userId);
        Task<bool> IsAllocationExist(string userId, int leaveTypeId, int period);
        Task<LeaveAllocation> GetUserAllocations(string userId, int leaveTypeId);
        Task AddAllocations(List<LeaveAllocation> allocations);

}