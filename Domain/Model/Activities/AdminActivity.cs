using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Domain.Model.Users;
using Domain.Model.TimeEntries;

namespace Domain.Model.Activities;

public class AdminActivity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public required XylosUser XylosUser { get; set; }
    public required ICollection<DetachedTimeEntry> TimeEntries {get; set;}
}
