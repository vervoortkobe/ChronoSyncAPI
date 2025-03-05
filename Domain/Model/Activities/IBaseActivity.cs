using Domain.Model.Users;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Domain.Model.Activities;

public interface IBaseActivity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public XylosUser XylosUser { get; set; }
}
