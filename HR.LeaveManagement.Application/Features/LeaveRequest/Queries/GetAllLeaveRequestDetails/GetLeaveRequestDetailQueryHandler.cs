using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Queries.GetAllLeaveRequestDetails
{
    public class GetLeaveRequestDetailQueryHandler : IRequestHandler<GetLeaveRequestDetailQuery, LeaveRequestDetailDto>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        public async Task<LeaveRequestDetailDto> Handle(GetLeaveRequestDetailQuery request, CancellationToken cancellationToken)
        {
            var leaveRequestFromDb = await _leaveRequestRepository.GetLeaveRequestWithDetailsByIdAsync(request.Id);
            var leaveRequest = _mapper.Map<LeaveRequestDetailDto>(leaveRequestFromDb);

            if (leaveRequestFromDb is null)
            {
                throw new NotFoundException(nameof(leaveRequestFromDb), request.Id);
            }
            return leaveRequest;
        }
    }
}
