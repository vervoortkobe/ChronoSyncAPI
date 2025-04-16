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
                    Activity = activities[0],
                    Date = new DateTime(2025, 3, 31),
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now.AddMinutes(224),
                    Break = 37,
                    Description = "Consulting AP Hogeschool"
                },
                new()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Activity = activities[0],
                    Date = new DateTime(2025, 4, 1),
                    Duration = 65,
                    Description = "Consulting AP Hogeschool"
                },

                new()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Activity = activities[1],
                    Date = new DateTime(2025, 4, 1),
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now.AddMinutes(71),
                    Break = 4,
                    Description = "Consulting AP Hogeschool"
                },
                new()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Activity = activities[1],
                    Date = new DateTime(2025, 4, 2),
                    Duration = 68,
                    Description = "Consulting AP Hogeschool"
                },

                new()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Activity = activities[2],
                    Date = new DateTime(2025, 3, 31),
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now.AddMinutes(302),
                    Break = 52,
                    Description = "Sprint meeting ThermoApp"
                },

                new()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Activity = activities[3],
                    Date = new DateTime(2025, 4, 1),
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now.AddMinutes(220),
                    Break = 22,
                    Description = "Vervoersplan wijzigen"
                },

                new()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Activity = activities[4],
                    Date = new DateTime(2025, 3, 31),
                    Duration = 123,
                    Description = "Overleg ChronoSync applicatie"
                },

                new()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Activity = activities[5],
                    Date = new DateTime(2025, 4, 2),
                    Duration = 245,
                    Description = "Analyse ChronoSync applicatie"
                },

                new()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Activity = activities[6],
                    Date = new DateTime(2025, 4, 2),
                    Duration = 280,
                    Description = "Bussen bekijken"
                },

                new()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Activity = activities[7],
                    Date = new DateTime(2025, 4, 2),
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now.AddMinutes(271),
                    Break = 30,
                    Description = "Grasjes planten"
                },

                new()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Activity = activities[8],
                    Date = new DateTime(2025, 3, 25),
                    Duration = 183,
                    Description = "GalAPagos programmeren"
                },
                new()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Activity = activities[8],
                    Date = new DateTime(2025, 3, 26),
                    Duration = 62,
                    Description = "Database GalAPagos opzetten"
                },

                new()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Activity = activities[9],
                    Date = new DateTime(2025, 3, 27),
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now.AddMinutes(264),
                    Break = 21,
                    Description = "Grasjes planten"
                },

                new()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Activity = activities[10],
                    Date = new DateTime(2025, 4, 15),
                    Duration = 62,
                    Description = "Database GalAPagos opzetten"
                },
                
                new()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Activity = activities[11],
                    Date = new DateTime(2025, 4, 16),
                    Duration = 8,
                    Description = "Database GalAPagos opzetten"
                },
            };

            if (collection.CountDocuments(FilterDefinition<TimeEntry>.Empty) <= 0)
                collection.InsertMany(timeEntries);
        }
    }
}