using Domain.Model.Activities;
using Domain.Model.TimeEntries;
using Domain.Model.Users;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Infrastructure.Seeding
{
    public static class ActivitySeeding
    {
        public static void Seed(IMongoDatabase database, List<XylosUser> users)
        {
            var collection = database.GetCollection<Activity>("Activities");

            var activities = new List<Activity>
            {
                new()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    XylosUser = users[0],
                    Organisation = "Consult Contract AP Hogeschool",
                    Project = "GalAPagos",
                    Location = "Campus Ellerman",
                    StartDate = new DateOnly(2025,3, 3),
                    EndDate = new DateOnly(3035, 3, 7),
                    HoursToSpend = 4,
                    Type = ActivityType.EFFORT
                },
                new()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    XylosUser = users[1],
                    Organisation = "Meeting Company Xylosophos",
                    Project = "OmniBus",
                    Location = "Meeting Room Obelix",
                    StartDate = new DateOnly(2025,3, 3),
                    EndDate = new DateOnly(3035, 3, 7),
                    HoursToSpend = 8,
                    Type = ActivityType.EFFORT
                },
                new()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    XylosUser = users[1],
                    Organisation = "Consult Contract AP Hogeschool",
                    Project = "GalAPagos",
                    Location = "Campus Ellerman",
                    StartDate = new DateOnly(2025,3, 5),
                    EndDate = new DateOnly(3035, 3, 5),
                    HoursToSpend = 5,
                    Type = ActivityType.TIME
                }
            };

            var filter = Builders<Activity>.Filter.Eq("_t", nameof(Activity));
            if (collection.CountDocuments(filter) == 0)
                collection.InsertMany(activities);

            TimeEntrySeeding.Seed(database, activities);
        }
    }
}