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
                // This week
                // Effort
                new()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    XylosUser = users[1],
                    Organisation = "Consult Contract AP Hogeschool",
                    Project = "GalAPagos",
                    Location = "Campus Ellerman",
                    StartDate = new DateTime(2025, 3, 31),
                    EndDate = new DateTime(2025, 4, 4),
                    HoursToSpend = 4,
                    CalculatedMinutesSpent = 252,
                    Type = ActivityType.EFFORT
                },
                new()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    XylosUser = users[1],
                    Organisation = "Consult Contract AP Hogeschool",
                    Project = "GalAPagos",
                    Location = "Campus Viaduct",
                    StartDate = new DateTime(2025, 3, 31),
                    EndDate = new DateTime(2025, 4, 4),
                    HoursToSpend = 4,
                    CalculatedMinutesSpent = 135,
                    Type = ActivityType.EFFORT
                },
                // Time
                new()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    XylosUser = users[1],
                    Organisation = "Software Company Thorios",
                    Project = "ThermoApp",
                    Location = "Antwerpselei 43, 2000 Antwerp",
                    StartDate = new DateTime(2025, 3, 31),
                    EndDate = new DateTime(2025, 3, 31),
                    HoursToSpend = 4,
                    CalculatedMinutesSpent = 250,
                    Type = ActivityType.TIME
                },
                new()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    XylosUser = users[1],
                    Organisation = "Vervoersmaatschappij DeLijn",
                    Project = "FlexApp",
                    Location = "Bushalte Roosevelt A3, 2000 Antwerp",
                    StartDate = new DateTime(2025, 4, 1),
                    EndDate = new DateTime(2025, 4, 1),
                    HoursToSpend = 3,
                    CalculatedMinutesSpent = 198,
                    Type = ActivityType.TIME
                },
                new()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    XylosUser = users[1],
                    Organisation = "Meeting Company Xylosophos",
                    Project = "ChronoSync",
                    Location = "Meeting Room Panoramix",
                    StartDate = new DateTime(2025, 3, 31),
                    EndDate = new DateTime(2025, 3, 31),
                    HoursToSpend = 2,
                    CalculatedMinutesSpent = 123,
                    Type = ActivityType.TIME
                },
                new()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    XylosUser = users[1],
                    Organisation = "Meeting Company Xylosophos",
                    Project = "ChronoSync",
                    Location = "Meeting Room Obelix",
                    StartDate = new DateTime(2025, 4, 2),
                    EndDate = new DateTime(2025, 4, 2),
                    HoursToSpend = 4,
                    CalculatedMinutesSpent = 245,
                    Type = ActivityType.TIME
                },
                new()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    XylosUser = users[1],
                    Organisation = "Meeting Company Xylosophos",
                    Project = "OmniBus",
                    Location = "Meeting Room Idefix",
                    StartDate = new DateTime(2025, 4, 2),
                    EndDate = new DateTime(2025, 4, 2),
                    HoursToSpend = 4,
                    CalculatedMinutesSpent = 280,
                    Type = ActivityType.TIME
                },
                new()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    XylosUser = users[1],
                    Organisation = "Garden Company Flexios",
                    Project = "Flox",
                    Location = "Vlindertuinstraat 1, 1940 Berchem",
                    StartDate = new DateTime(2025, 4, 2),
                    EndDate = new DateTime(2025, 4, 2),
                    HoursToSpend = 4,
                    CalculatedMinutesSpent = 241,
                    Type = ActivityType.TIME
                },
                // Previous week
                // Effort
                new()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    XylosUser = users[1],
                    Organisation = "Consult Contract AP Hogeschool",
                    Project = "GalAPagos",
                    Location = "Campus Viaduct",
                    StartDate = new DateTime(2025, 3, 24),
                    EndDate = new DateTime(2025, 3, 27),
                    HoursToSpend = 4,
                    CalculatedMinutesSpent = 245,
                    Type = ActivityType.EFFORT
                },
                /// Time
                new()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    XylosUser = users[1],
                    Organisation = "Software Company Thorios",
                    Project = "ThermoApp",
                    Location = "Antwerpselei 43, 2000 Antwerp",
                    StartDate = new DateTime(2025, 3, 27),
                    EndDate = new DateTime(2025, 3, 27),
                    HoursToSpend = 4,
                    CalculatedMinutesSpent = 243,
                    Type = ActivityType.TIME
                },
            };

            if (collection.CountDocuments(FilterDefinition<Activity>.Empty) <= 0)
                collection.InsertMany(activities);

            TimeEntrySeeding.Seed(database, activities);
        }
    }
}