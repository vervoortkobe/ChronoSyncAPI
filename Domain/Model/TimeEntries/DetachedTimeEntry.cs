using Domain.Model.Activities;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Domain.Model.TimeEntries;

public class DetachedTimeEntry
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public required AdminActivity AdminActivity { get; set; }
    public required Category Category { get; set; }
    public required DateTime Date { get; set; }
    public DateTime? StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    // Amount of minutes
    public int? Duration { get; set; }
    public required string Description { get; set; }
}

public enum Category
{
    LEARN, 
    PROJECT, 
    CLIENT, 
    OTHER
}
