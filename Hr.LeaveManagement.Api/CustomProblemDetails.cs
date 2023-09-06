using Microsoft.AspNetCore.Mvc;

namespace Hr.LeaveManagement.Api
{
    public class CustomProblemDetails : ProblemDetails
    {
        public IDictionary<string, string[]> Errors { get; set; } = new Dictionary<string, string[]>();
    }
}
