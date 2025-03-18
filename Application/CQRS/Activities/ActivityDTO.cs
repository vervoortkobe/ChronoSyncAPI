using Domain.Model.Activities;
using Domain.Model.Users;

namespace Application.CQRS.Activities;

public class ActivityDTO
{
    public required string Id { get; set; }
    public required XylosUser XylosUser { get; set; }
    public required string Organisation { get; set; }
    public required string Project { get; set; }
    public required string Location { get; set; }
    public required DateTime StartDate { get; set; }
    public required DateTime EndDate { get; set; }
    public required int HoursToSpend { get; set; }
    public required ActivityType Type { get; set; }
}