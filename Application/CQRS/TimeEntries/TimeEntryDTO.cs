using Domain.Model.Activities;

namespace Application.CQRS.TimeEntries;

public class TimeEntryDTO
{
    public required string Id { get; set; }
    public required Activity Activity { get; set; }
    public DateTime? StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public int? Duration { get; set; }
}
