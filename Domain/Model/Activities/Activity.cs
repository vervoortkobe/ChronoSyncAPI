using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Domain.Model.Users;
using Domain.Model.TimeEntries;

namespace Domain.Model.Activities;

public class Activity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public required XylosUser XylosUser { get; set; }
    public required Organisation Organisation { get; set; }
    public required Project Project { get; set; }
    public required string Location { get; set; }
    public required DateOnly StartDate { get; set; }
    public required DateOnly EndDate { get; set; }
    public required int HoursToSpend { get; set; }
    public required ActivityType Type { get; set; }
    public required ICollection<TimeEntry> TimeEntries { get; set; }
}

public enum ActivityType
{
    TIME,
    EFFORT
}
