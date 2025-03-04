using Domain.Model.Activities;
using Domain.Model.TimeEntries;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Infrastructure.Seeding
{
    public static class TimeEntrySeeding
    {
        public static void Seed(IMongoDatabase database, List<Activity> activities)
        {
            var collection = database.GetCollection<TimeEntry>("TimeEntries");

            var timeEntries = new List<TimeEntry>
            {
                new()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Activity = activities[1],
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now.AddMinutes(334)
                },
                new()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Activity = activities[1],
                    Duration = 146
                },
                new()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Activity = activities[2],
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now.AddMinutes(306)
                }
            };

            if (collection.CountDocuments(FilterDefinition<TimeEntry>.Empty) <= 0)
                collection.InsertMany(timeEntries);
        }
    }
}