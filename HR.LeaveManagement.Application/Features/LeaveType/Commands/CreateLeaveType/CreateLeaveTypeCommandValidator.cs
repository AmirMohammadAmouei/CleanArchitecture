using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType
{
    public class CreateLeaveTypeCommandValidator : AbstractValidator<CreateLeaveTypeCommand>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public CreateLeaveTypeCommandValidator(ILeaveTypeRepository leaveTypeRepository)
        {

            _leaveTypeRepository = leaveTypeRepository;


            RuleFor(x => x.Name).NotEmpty().
                WithMessage("{PropertyName} is required").NotNull().MaximumLength(70)
                .WithMessage("{PropertyName} must be fewer than 70 character");

            RuleFor(x => x.DefaultDays).GreaterThan(100).
                WithMessage("{PropertyName} cannot exceed 100").LessThan(1)
                .WithMessage("{PropertyName} cannot be less than 1");


            RuleFor(x => x).
                MustAsync(LeaveTypeNameUnique).WithMessage("Leave type alredy exists");

           
        }

        private Task<bool> LeaveTypeNameUnique(CreateLeaveTypeCommand command, CancellationToken token)
        {
            return _leaveTypeRepository.IsLeaveTypeUnique(command.Name);
        }
    }
}
