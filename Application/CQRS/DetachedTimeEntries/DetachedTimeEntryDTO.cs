using Domain.Model.Activities;
using Domain.Model.TimeEntries;

namespace Application.CQRS.DetachedTimeEntries;

public class DetachedTimeEntryDTO
{
    public string? Id { get; set; }
    public AdminActivity? AdminActivity { get; set; }
    public required Category Category { get; set; }
    public required DateTime Date { get; set; }
    public DateTime? StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public int? Break { get; set; }
    public int? Duration { get; set; }
    public required string Description { get; set; }
}
