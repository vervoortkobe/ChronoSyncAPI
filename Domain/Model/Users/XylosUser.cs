using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Domain.Model.Activities;

namespace Domain.Model.Users;

public class XylosUser
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public required string UPN { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required Function Function { get; set; }
    public string? Picture { get; set; }

    //public required AdminActivity AdminActivity { get; set; }
    //public required ICollection<Activity> Activities { get; set; }
}

public enum Function
{
    SERVICEDESK,
    TEAMLEAD,
    ADMINISTRATOR,
    INFRA
}
