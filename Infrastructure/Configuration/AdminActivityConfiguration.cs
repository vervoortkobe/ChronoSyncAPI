using Domain.Model.Activities;
using MongoDB.Bson.Serialization;

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
            });
        }
    }
}