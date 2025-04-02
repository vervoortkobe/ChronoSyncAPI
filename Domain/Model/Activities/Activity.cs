using Domain.Model.Users;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Domain.Model.Activities;

public class Activity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public required XylosUser XylosUser { get; set; }
    public required string Organisation { get; set; }
    public required string Project { get; set; }
    public required string Location { get; set; }
    public required DateTime StartDate { get; set; }
    public required DateTime EndDate { get; set; }
    public required int HoursToSpend { get; set; }
    public int? CalculatedMinutesSpent { get; set; }
    public required ActivityType Type { get; set; }
}

public enum ActivityType
{
    TIME,
    EFFORT
}
