using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDetailes
{
    public record GetLeaveTypeDetailsQuery(int id) : IRequest<LeaveTypeDetailsDto>;

}
