using Domain.Model.Users;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Domain.Model.Activities;

public class BaseActivity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public required XylosUser XylosUser { get; set; }
}
