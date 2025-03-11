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
                    EndTime = DateTime.Now.AddMinutes(334),
                    Description = "Meeting with company Xylosophos"
                },
                new()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Activity = activities[1],
                    Duration = 146,
                    Description = "Meeting with company Xylosophos"
                },
                new()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Activity = activities[2],
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now.AddMinutes(306),
                    Description = "Consulting AP Hogeschool"
                }
            };

            var filter = Builders<TimeEntry>.Filter.Eq("_t", nameof(TimeEntry));
            if (collection.CountDocuments(filter) == 0)
                collection.InsertMany(timeEntries);
        }
    }
}