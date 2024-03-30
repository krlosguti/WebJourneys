using Microsoft.AspNetCore.Mvc;

namespace WebJourneys.Presentation.Models
{
    public class CustomProblemDetails: ProblemDetails
    {
        public IDictionary<string, string[]> Errors { get; set; } = new Dictionary<string, string[]>();
    }
}
