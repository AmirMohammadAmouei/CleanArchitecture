using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Shared
{
    public class BaseLeaveRequestValidator : AbstractValidator<BaseLeaveRequest>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public BaseLeaveRequestValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;

            RuleFor(x => x.StartDate).LessThan(x => x.EndDate)
                .WithMessage("{PropertyName} must be before {ComparisonValue}");

            RuleFor(x => x.EndDate).GreaterThan(x => x.StartDate)
                .WithMessage("{PropertyName} must be after {ComparisonValue}");

            RuleFor(x => x.LeaveTypeId).GreaterThan(0).MustAsync(LeaveTypeMustExistAsync)
                .WithMessage("{PropertyName} does not exist.");
        }

        private async Task<bool> LeaveTypeMustExistAsync(int id, CancellationToken arg2)
        {
            var findLeaveTYpeById = await _leaveTypeRepository.GetByIdAsync(id);
            return findLeaveTYpeById != null;
        }
    }
}
