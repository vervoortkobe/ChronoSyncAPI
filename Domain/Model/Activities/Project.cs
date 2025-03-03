using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Domain.Model.Activities;

public class Project
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public required string Name { get; set; }
    public required Organisation Organisation { get; set; }
}
