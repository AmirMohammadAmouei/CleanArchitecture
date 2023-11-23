using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Persistence.DataBaseContext;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        public LeaveRequestRepository(HRDataBaseContext context) : base(context)
        {
        }

        public async Task<LeaveRequest> GetLeaveRequestWithDetailsByIdAsync(int id)
        {
            return await _context.LeaveRequest.Include(x =>
                x.LeaveType).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestListWithDetailsAsync()
        {
            return await _context.LeaveRequest.Where(x => !string.IsNullOrEmpty(x.RequestingEmployeeId))
                .Include(x => x.LeaveType).AsNoTracking().ToListAsync();
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestListWithDetailsByUserIdAsync(string userId)
        {
            return await _context.LeaveRequest.Where(x => 
                    x.RequestingEmployeeId == userId).Include(x => x.LeaveType)
                .AsNoTracking().ToListAsync();
        }
    }
}
