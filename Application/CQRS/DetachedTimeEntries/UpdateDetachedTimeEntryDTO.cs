using Domain.Model.Activities;
using Domain.Model.TimeEntries;

namespace Application.CQRS.DetachedTimeEntries;

public class UpdateDetachedTimeEntryDTO
{
    public required string Id { get; set; }
    public Category? Category { get; set; }
    public DateOnly? Date { get; set; }
    public DateTime? StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public int? Duration { get; set; }
    public string? Description { get; set; }
}
