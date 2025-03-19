using Domain.Model.Activities;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Domain.Model.TimeEntries;

public class TimeEntry
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public required Activity Activity { get; set; }
    public required DateTime Date { get; set; }
    public DateTime? StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    // Amount of minutes
    public int? Break { get; set; }
    // Amount of minutes
    public int? Duration { get; set; }
    public required string Description { get; set; }
}
