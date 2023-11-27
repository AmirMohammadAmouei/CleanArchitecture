using HR.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocation;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetail
{
    public class GetLeaveTypeAllocationDetailQuery : IRequest<LeaveAllocationDetailDto>
    {
        public int Id { get; set; }
    }
}
