using Domain.Model.Activities;
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
                    StartDate = new DateTime(2025, 3, 3),
                    EndDate = new DateTime(2025, 3, 7),
                    HoursToSpend = 4,
                    CalculatedMinutesSpent = 0,
                    Type = ActivityType.EFFORT
                },
                new()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    XylosUser = users[1],
                    Organisation = "Meeting Company Xylosophos",
                    Project = "OmniBus",
                    Location = "Meeting Room Obelix",
                    StartDate = new DateTime(2025, 3, 3),
                    EndDate = new DateTime(2025, 3, 7),
                    HoursToSpend = 8,
                    CalculatedMinutesSpent = 446,
                    Type = ActivityType.EFFORT
                },
                new()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    XylosUser = users[1],
                    Organisation = "Consult Contract AP Hogeschool",
                    Project = "GalAPagos",
                    Location = "Campus Ellerman",
                    StartDate = new DateTime(2025, 3, 5),
                    EndDate = new DateTime(2025, 3, 5),
                    HoursToSpend = 5,
                    CalculatedMinutesSpent = 278,
                    Type = ActivityType.TIME
                },
                new()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    XylosUser = users[1],
                    Organisation = "Meeting Company Xylosophos",
                    Project = "OmniBus",
                    Location = "Meeting Room Obelix",
                    StartDate = new DateTime(2025, 4, 2),
                    EndDate = new DateTime(2025, 4, 2),
                    HoursToSpend = 8,
                    CalculatedMinutesSpent = 0,
                    Type = ActivityType.TIME
                }
            };

            if (collection.CountDocuments(FilterDefinition<Activity>.Empty) <= 0)
                collection.InsertMany(activities);

            TimeEntrySeeding.Seed(database, activities);
        }
    }
}