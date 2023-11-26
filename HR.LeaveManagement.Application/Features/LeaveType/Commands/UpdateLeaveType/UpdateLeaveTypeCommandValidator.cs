using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.UpdateLeaveType
{
    public class UpdateLeaveTypeCommandValidator : AbstractValidator<UpdateLeaveTypeCommand>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public UpdateLeaveTypeCommandValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;

            RuleFor(x => x.Id).NotNull().MustAsync(LeaveTypeMustExist);
            RuleFor(x => x.Name).NotEmpty()
                .WithMessage("{PropertyName} is required").NotNull()
                .MaximumLength(70).WithMessage("{PropertyName} mus be fewer than 70 characters");

            RuleFor(x => x.DefaultDays).LessThan(100)
                .WithMessage("{PropertyName} can not exceed 100").
                GreaterThan(1).WithMessage("{PropertyName} can not less than 1");

        }

        private async Task<bool> LeaveTypeMustExist(int id, CancellationToken arg2)
        {
            var leaveType = await _leaveTypeRepository.GetByIdAsync(id);
            return leaveType != null;
        }
    }
}
