using Domain.Model.Activities;

namespace Application.CQRS.TimeEntries;

public class TimeEntryDTO
{
    public string? Id { get; set; }
    public Activity? Activity { get; set; }
    public required DateTime Date { get; set; }
    public DateTime? StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public int? Duration { get; set; }
    public required string Description { get; set; }
}
