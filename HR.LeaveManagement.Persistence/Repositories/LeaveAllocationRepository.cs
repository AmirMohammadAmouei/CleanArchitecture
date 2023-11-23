using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Persistence.DataBaseContext;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        public LeaveAllocationRepository(HRDataBaseContext context) : base(context)
        {

        }

        public async Task<LeaveAllocation> GetLeaveAllocationDetailsByIdAsync(int id)
        {
            var result = await _context.LeaveAllocation.Include(x =>
                x.LeaveType).FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationListWithDetailsAsync()
        {
            return await _context.LeaveAllocation.Include(x =>
                x.LeaveType).AsNoTracking().ToListAsync();
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationListWithDetailsByUserIdAsync(string userId)
        {
            var result = await _context.LeaveAllocation.Include(x =>
                x.LeaveType).Where(x => x.EmployeeId == userId).ToListAsync();

            return result;
        }

        public async Task<bool> IsAllocationExist(string userId, int leaveTypeId, int period)
        {
            return await _context.LeaveAllocation.AnyAsync(x =>
                x.EmployeeId == userId && x.LeaveTypeId == leaveTypeId && x.Period == period);
        }

        public async Task<LeaveAllocation> GetUserAllocations(string userId, int leaveTypeId)
        {
            return await _context.LeaveAllocation.FirstOrDefaultAsync(x =>
                x.EmployeeId == userId && x.LeaveTypeId == leaveTypeId);
        }

        public async Task AddAllocations(List<LeaveAllocation> allocations)
        {
             await _context.AddRangeAsync(allocations);
        }
    }
}
