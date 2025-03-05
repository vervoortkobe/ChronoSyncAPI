using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Domain.Model.Activities;

namespace Domain.Model.TimeEntries;

public interface IBaseTimeEntry
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public IBaseActivity Activity { get; set; }
    public DateTime? StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    // Amount of minutes
    public int? Duration { get; set; }
    public string Description { get; set; }
}
