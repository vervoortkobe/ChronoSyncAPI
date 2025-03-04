using Domain.Model.TimeEntries;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace Infrastructure.Configuration;

public class TimeEntryConfiguration
{
    public static void Configure()
    {
        if (!BsonClassMap.IsClassMapRegistered(typeof(TimeEntry)))
        {
            BsonClassMap.RegisterClassMap<TimeEntry>(cm =>
            {
                cm.AutoMap();
                cm.SetIgnoreExtraElements(true);

                cm.MapIdMember(c => c.Id).SetSerializer(new StringSerializer(BsonType.ObjectId));
                cm.MapMember(c => c.Activity).SetIsRequired(true);
                cm.MapMember(c => c.StartTime).SetIsRequired(false);
                cm.MapMember(c => c.EndTime).SetIsRequired(false);
                cm.MapMember(c => c.Duration).SetIsRequired(false);
            });
        }
    }
}