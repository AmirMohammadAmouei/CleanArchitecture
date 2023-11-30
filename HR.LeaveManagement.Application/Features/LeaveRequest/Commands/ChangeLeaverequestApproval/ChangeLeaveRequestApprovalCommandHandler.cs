using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Commands.ChangeLeaveRequestApproval
{
    public class ChangeLeaveRequestApprovalCommandHandler : IRequestHandler<ChangeLeaveRequestApprovalCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveRequestRepository _leaveRequestRepository;

        public ChangeLeaveRequestApprovalCommandHandler(IMapper mapper, ILeaveRequestRepository leaveRequestRepository)
        {
            _mapper = mapper;
            _leaveRequestRepository = leaveRequestRepository;
        }

        public async Task<Unit> Handle(ChangeLeaveRequestApprovalCommand request, CancellationToken cancellationToken)
        {
            var findLeaveRequestById = await _leaveRequestRepository.GetByIdAsync(request.Id);

            if (findLeaveRequestById is null)
                throw new NotFoundException(nameof(LeaveRequest), request.Id);

            findLeaveRequestById.Approved = request.Approved;
            await _leaveRequestRepository.UpdateAsync(findLeaveRequestById);

            //if request is approved,get and update the employee's allocation

            //Implement Email Service
            return Unit.Value;
        }
    }
}
