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
                    Date = new DateTime(2025, 3, 9),
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now.AddMinutes(334),
                    Break = 37,
                    Description = "Meeting with company Xylosophos"
                },
                new()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Activity = activities[1],
                    Date = new DateTime(2025, 3, 10),
                    Duration = 146,
                    Description = "Meeting with company Xylosophos"
                },
                new()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Activity = activities[2],
                    Date = new DateTime(2025, 3, 11),
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now.AddMinutes(306),
                    Break = 28,
                    Description = "Consulting AP Hogeschool"
                }
            };

            if (collection.CountDocuments(FilterDefinition<TimeEntry>.Empty) <= 0)
                collection.InsertMany(timeEntries);
        }
    }
}