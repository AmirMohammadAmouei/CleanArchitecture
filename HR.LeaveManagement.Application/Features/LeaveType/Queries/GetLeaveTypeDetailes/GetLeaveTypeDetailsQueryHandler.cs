using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDetailes
{
    public class GetLeaveTypeDetailsQueryHandler : IRequestHandler<GetLeaveTypeDetailsQuery, LeaveTypeDetailsDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public GetLeaveTypeDetailsQueryHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }
        public async Task<LeaveTypeDetailsDto> Handle(GetLeaveTypeDetailsQuery request, CancellationToken cancellationToken)
        { 
            //find record in database by id
            var findLeaveTypeDetailsFromDbById = await _leaveTypeRepository.GetByIdAsync(request.id);

            //check is exist or not
            if (findLeaveTypeDetailsFromDbById == null)
                throw new Exception("The record Not found");

            //convert db object to DTO object
            var result = _mapper.Map<LeaveTypeDetailsDto>(findLeaveTypeDetailsFromDbById);

            return result;
        }
    }
}
