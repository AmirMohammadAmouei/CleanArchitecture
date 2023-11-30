using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequestList
{
    public class GetLeaveRequestQueryHandler : IRequestHandler<GetLeaveRequestQuery, List<LeaveRequestListDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly ILeaveRequestRepository _leaveRequestRepository;

        public GetLeaveRequestQueryHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository,
            ILeaveRequestRepository leaveRequestRepository)
        {
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
            _leaveRequestRepository = leaveRequestRepository;

        }
        public async Task<List<LeaveRequestListDto>> Handle(GetLeaveRequestQuery request, CancellationToken cancellationToken)
        {
            var leaveRequest = new List<Domain.LeaveRequest>();
            var requests = _mapper.Map<List<LeaveRequestListDto>>(leaveRequest);

            return requests;
        }
    }
}
