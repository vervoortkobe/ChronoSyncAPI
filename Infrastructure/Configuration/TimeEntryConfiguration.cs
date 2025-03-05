using Domain.Model.TimeEntries;
using MongoDB.Bson.Serialization;

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
            });
        }
    }
}