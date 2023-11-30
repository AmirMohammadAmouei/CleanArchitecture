using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveType.Commands.DeleteLeaveType;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Command.DeleteLeaveAllocation
{
    public class DeleteLeaveAllocationHandler : IRequestHandler<DeleteLeaveAllocationCommand,Unit>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;

        public DeleteLeaveAllocationHandler(IMapper mapper, ILeaveAllocationRepository leaveAllocationRepository)
        {
            _mapper = mapper;
            _leaveAllocationRepository = leaveAllocationRepository;
        }

        public async Task<Unit> Handle(DeleteLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var findLeaveAllocationById = await _leaveAllocationRepository.GetByIdAsync(request.Id);

            if (findLeaveAllocationById is null)
                throw new NotFoundException(nameof(findLeaveAllocationById), request.Id);

            await _leaveAllocationRepository.DeleteAsync(findLeaveAllocationById);

            return Unit.Value;
        }
    }
}
