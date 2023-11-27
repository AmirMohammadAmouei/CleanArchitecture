using System.Diagnostics.Contracts;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Command.DeleteLeaveAllocation
{
    public class DeleteLeaveAllocationCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
