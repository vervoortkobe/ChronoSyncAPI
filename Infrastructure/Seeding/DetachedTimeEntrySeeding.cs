using Domain.Model.Activities;
using Domain.Model.TimeEntries;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Infrastructure.Seeding
{
    public static class DetachedTimeEntrySeeding
    {
        public static void Seed(IMongoDatabase database, List<AdminActivity> adminActivities)
        {
            var collection = database.GetCollection<BaseTimeEntry>("TimeEntries");

            var timeEntries = new List<DetachedTimeEntry>
            {
                new()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Activity = adminActivities[0],
                    Category = Category.CLIENT,
                    Date = new DateOnly(2025, 3, 3),
                    Description = "Bezig gehouden met CLIENT XYZ",
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now.AddMinutes(105)
                },
                new()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Activity = adminActivities[1],
                    Category = Category.PROJECT,
                    Date = new DateOnly(2025, 2, 27),
                    Description = "Bezig gehouden met PROJECT XYZ",
                    Duration = 72
                },
                new()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Activity = adminActivities[2],
                    Category = Category.LEARN,
                    Date = new DateOnly(2025, 2, 25),
                    Description = "Bezig gehouden met LEARN XYZ",
                    Duration = 95
                }
            };

            var filter = Builders<BaseTimeEntry>.Filter.Eq("_t", nameof(DetachedTimeEntry));
            if (collection.CountDocuments(filter) == 0)
                collection.InsertMany(timeEntries);
        }
    }
}