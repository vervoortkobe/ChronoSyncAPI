using Domain.Model.Activities;
using Domain.Model.TimeEntries;
using Domain.Model.Users;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Infrastructure.Seeding
{
    public static class DetachedTimeEntrySeeding
    {
        public static void Seed(IMongoDatabase database, List<AdminActivity> adminActivities)
        {
            var collection = database.GetCollection<DetachedTimeEntry>("TimeEntries");

            if (collection.CountDocuments(FilterDefinition<DetachedTimeEntry>.Empty) > 0)
                return;

            var detachedTimeEntries = new List<DetachedTimeEntry>
            {
                new()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    AdminActivity = adminActivities[0],
                    Category = Category.CLIENT,
                    Date = new DateOnly(2025, 3, 3),
                    Description = "Bezig gehouden met CLIENT XYZ",
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now.AddMinutes(105)
                },
                new()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    AdminActivity = adminActivities[1],
                    Category = Category.PROJECT,
                    Date = new DateOnly(2025, 2, 27),
                    Description = "Bezig gehouden met PROJECT XYZ",
                    Duration = 4320
                },
                new()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    AdminActivity = adminActivities[2],
                    Category = Category.LEARN,
                    Date = new DateOnly(2025, 2, 25),
                    Description = "Bezig gehouden met LEARN XYZ",
                    Duration = 5700
                }
            };

            collection.InsertMany(detachedTimeEntries);
        }
    }
}