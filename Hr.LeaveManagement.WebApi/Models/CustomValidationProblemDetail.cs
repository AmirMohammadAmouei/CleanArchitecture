using Microsoft.AspNetCore.Mvc;

namespace Hr.LeaveManagement.WebApi.Models
{
    public class CustomValidationProblemDetail : ProblemDetails
    {
        public IDictionary<string, string[]> Errors { get; set; } = new Dictionary<string, string[]>();
    }
}
