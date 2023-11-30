using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Queries.GetAllLeaveRequestDetails
{
    public class GetLeaveRequestDetailQuery:IRequest<LeaveRequestDetailDto>
    {
        public int Id { get; set; }
    }
}
