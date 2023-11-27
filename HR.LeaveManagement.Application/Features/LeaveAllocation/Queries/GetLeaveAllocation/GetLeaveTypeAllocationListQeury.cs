using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocation
{
    public record GetLeaveTypeAllocationListQuery : IRequest<List<LeaveAllocationDto>>;

}
