﻿using AutoMapper;
using HR.LeaveManagement.Application.Features.LeaveAllocation.Command.CreateLeaveAllocation;
using HR.LeaveManagement.Application.Features.LeaveAllocation.Command.UpdateLeaveAllocation;
using HR.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocation;
using HR.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetail;
using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.MappingProfile
{
    public class LeaveAllocationProfile : Profile
    {
        public LeaveAllocationProfile()
        {
            CreateMap<LeaveAllocationDto, LeaveAllocation>().ReverseMap();
            CreateMap<LeaveAllocation, LeaveAllocationDetailDto>();
            CreateMap<CreateLeaveAllocationCommand, LeaveAllocation > ();
            CreateMap<UpdateLeaveAllocationCommand, LeaveAllocation >();
        }
    }
}
