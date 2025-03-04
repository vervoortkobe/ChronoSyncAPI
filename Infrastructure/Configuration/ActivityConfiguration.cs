using Domain.Model.Activities;
using Domain.Model.TimeEntries;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace Infrastructure.Configuration;

public class ActivityConfiguration
{
    public static void Configure()
    {
        if (!BsonClassMap.IsClassMapRegistered(typeof(Activity)))
        {
            BsonClassMap.RegisterClassMap<Activity>(cm =>
            {
                cm.AutoMap();
                cm.SetIgnoreExtraElements(true);

                cm.MapIdMember(c => c.Id).SetSerializer(new StringSerializer(BsonType.ObjectId));
                cm.MapMember(c => c.XylosUser).SetIsRequired(true);
                cm.MapMember(c => c.Organisation).SetIsRequired(true);
                cm.MapMember(c => c.Project).SetIsRequired(true);
                cm.MapMember(c => c.Location).SetIsRequired(true);
                cm.MapMember(c => c.StartDate).SetIsRequired(true);
                cm.MapMember(c => c.EndDate).SetIsRequired(true);
                cm.MapMember(c => c.HoursToSpend).SetIsRequired(true);
                cm.MapMember(c => c.Type).SetIsRequired(true);
                cm.MapMember(c => c.TimeEntries).SetDefaultValue(new List<TimeEntry>());

                cm.MapMember(c => c.StartDate)
                  .SetSerializer(new DateOnlySerializer());
                cm.MapMember(c => c.EndDate)
                  .SetSerializer(new DateOnlySerializer());
            });
        }
    }
}

// Custom serializer for DateOnly (since MongoDB does not natively support it)
public class DateOnlySerializer : SerializerBase<DateOnly>
{
    public override DateOnly Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
    {
        var dateTime = context.Reader.ReadDateTime();
        return DateOnly.FromDateTime(DateTime.UnixEpoch.AddMilliseconds(dateTime));
    }

    public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, DateOnly value)
    {
        var dateTime = value.ToDateTime(TimeOnly.MinValue);
        var milliseconds = (dateTime - DateTime.UnixEpoch).TotalMilliseconds;
        context.Writer.WriteDateTime((long)milliseconds);
    }
}