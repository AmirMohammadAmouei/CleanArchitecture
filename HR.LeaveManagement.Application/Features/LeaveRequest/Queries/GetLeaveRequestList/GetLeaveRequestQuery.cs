using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequestList
{
    public class GetLeaveRequestQuery : IRequest<List<LeaveRequestListDto>>
    {
    }
}
