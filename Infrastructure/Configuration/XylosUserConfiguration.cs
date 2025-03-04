using Domain.Model.Activities;
using Domain.Model.Users;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace Infrastructure.Configuration;

public class XylosUserConfiguration
{
    public static void Configure()
    {
        if (!BsonClassMap.IsClassMapRegistered(typeof(XylosUser)))
        {
            BsonClassMap.RegisterClassMap<XylosUser>(cm =>
            {
                cm.AutoMap();
                cm.SetIgnoreExtraElements(true);

                cm.MapIdMember(c => c.Id).SetSerializer(new StringSerializer(BsonType.ObjectId));
                cm.MapMember(c => c.UPN).SetIsRequired(true);
                cm.MapMember(c => c.FirstName).SetIsRequired(true);
                cm.MapMember(c => c.LastName).SetIsRequired(true);
                cm.MapMember(c => c.Email).SetIsRequired(true);
                cm.MapMember(c => c.Function).SetIsRequired(true);
                cm.MapMember(c => c.Picture).SetIsRequired(false);
            });
        }
    }
}