using Domain.Model.Activities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace Infrastructure.Configuration;

public class AdminActivityConfiguration
{
    public static void Configure()
    {
        if (!BsonClassMap.IsClassMapRegistered(typeof(AdminActivity)))
        {
            BsonClassMap.RegisterClassMap<AdminActivity>(cm =>
            {
                cm.AutoMap();
                cm.SetIgnoreExtraElements(true);

                cm.MapIdMember(c => c.Id).SetSerializer(new StringSerializer(BsonType.ObjectId));
                cm.MapMember(c => c.XylosUser).SetIsRequired(true);
            });
        }
    }
}