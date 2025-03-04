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

                cm.MapIdMember(c => c.Id).SetSerializer(new StringSerializer(BsonType.ObjectId));
                cm.MapMember(c => c.AdminActivity).SetIsRequired(true);
                cm.MapMember(c => c.Category).SetIsRequired(true);
                cm.MapMember(c => c.Date).SetIsRequired(true);
                cm.MapMember(c => c.StartTime).SetIsRequired(false);
                cm.MapMember(c => c.EndTime).SetIsRequired(false);
                cm.MapMember(c => c.Duration).SetIsRequired(false);
                cm.MapMember(c => c.Description).SetIsRequired(true);
            });
        }
    }
}