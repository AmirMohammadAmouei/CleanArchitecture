using AutoMapper;
using HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using HR.LeaveManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDetailes;
using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.MappingProfile
{
    public class LeaveTypeProfile : Profile
    {
        public LeaveTypeProfile()
        {
            //Convert DTO class to domain Entity and back
            CreateMap<LeaveTypeDto, LeaveType>().ReverseMap();
            CreateMap<LeaveTypeDetailsDto, LeaveType>().ReverseMap();
        }
    }
}
