using System.Diagnostics.Contracts;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Command.DeleteLeaveAllocation
{
    public class DeleteLeaveAllocationCommand : IRequest
    {
        public int Id { get; set; }
    }
}
