using Domain.Model.Users;

namespace Domain.Model.Activities;

public class GetActivityDTO
{
    public required string Id { get; set; }
    public required XylosUser XylosUser { get; set; }
    public required string Organisation { get; set; }
    public required string Project { get; set; }
    public required string Location { get; set; }
    public required DateOnly StartDate { get; set; }
    public required DateOnly EndDate { get; set; }
    public required int HoursToSpend { get; set; }
    public required ActivityType Type { get; set; }
}