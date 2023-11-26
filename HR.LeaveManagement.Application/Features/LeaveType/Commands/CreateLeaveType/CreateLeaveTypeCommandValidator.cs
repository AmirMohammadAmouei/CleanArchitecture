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

            RuleFor(x => x.DefaultDays).LessThan(100).
                WithMessage("{PropertyName} cannot exceed 100").GreaterThan(1)
                .WithMessage("{PropertyName} cannot be less than 1");


            RuleFor(x => x).
                MustAsync(LeaveTypeNameUnique).WithMessage("Leave type already exists");


        }

        private Task<bool> LeaveTypeNameUnique(CreateLeaveTypeCommand command, CancellationToken token)
        {
            return _leaveTypeRepository.IsLeaveTypeUnique(command.Name);
        }
    }
}
