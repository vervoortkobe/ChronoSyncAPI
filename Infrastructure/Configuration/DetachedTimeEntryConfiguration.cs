using Domain.Model.TimeEntries;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace Infrastructure.Configuration;

public class DetachedTimeEntryConfiguration
{
    public static void Configure()
    {
        if (!BsonClassMap.IsClassMapRegistered(typeof(DetachedTimeEntry)))
        {
            BsonClassMap.RegisterClassMap<DetachedTimeEntry>(cm =>
            {
                cm.AutoMap();
                cm.SetIgnoreExtraElements(true);

                cm.MapMember(c => c.Category).SetIsRequired(true);
                cm.MapMember(c => c.Date).SetIsRequired(true);
            });
        }
    }
}