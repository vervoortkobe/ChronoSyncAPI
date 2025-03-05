using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Domain.Model.Activities;

namespace Domain.Model.TimeEntries;

public class TimeEntry : IBaseTimeEntry
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public required IBaseActivity Activity { get; set; }
    public DateTime? StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    // Amount of minutes
    public int? Duration { get; set; }
    public required string Description { get; set; }
}
