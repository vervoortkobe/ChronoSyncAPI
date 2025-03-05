using Domain.Model.Activities;
using Domain.Model.TimeEntries;

namespace Application.CQRS.DetachedTimeEntries;

public class GetDetachedTimeEntryDTO
{
    public required string Id { get; set; }
    public required AdminActivity AdminActivity { get; set; }
    public required Category Category { get; set; }
    public required DateOnly Date { get; set; }
    public DateTime? StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public int? Duration { get; set; }
    public required string Description { get; set; }
}
