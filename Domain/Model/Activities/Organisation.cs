using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Domain.Model.Activities;

public class Organisation
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public required string Name { get; set; }
    public required ICollection<Project> Projects { get; set; }
}
