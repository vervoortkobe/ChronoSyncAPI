namespace Domain.Model.Activities;

public class Activity : BaseActivity
{
    public required string Organisation { get; set; }
    public required string Project { get; set; }
    public required string Location { get; set; }
    public required DateOnly StartDate { get; set; }
    public required DateOnly EndDate { get; set; }
    public required int HoursToSpend { get; set; }
    public required ActivityType Type { get; set; }
}

public enum ActivityType
{
    TIME,
    EFFORT
}
