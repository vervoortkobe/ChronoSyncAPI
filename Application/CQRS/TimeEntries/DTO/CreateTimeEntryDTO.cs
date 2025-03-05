using Domain.Model.Activities;

namespace Application.CQRS.TimeEntries.DTO;

public class CreateTimeEntryDTO
{
    public required Activity Activity { get; set; }
    public DateTime? StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public int? Duration { get; set; }
}
