﻿using Domain.Model.Activities;
using Domain.Model.TimeEntries;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Infrastructure.Seeding
{
    public static class DetachedTimeEntrySeeding
    {
        public static void Seed(IMongoDatabase database, List<AdminActivity> adminActivities)
        {
            var collection = database.GetCollection<DetachedTimeEntry>("DetachedTimeEntries");

            var detachedTimeEntries = new List<DetachedTimeEntry>
            {
                new()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    AdminActivity = adminActivities[0],
                    Category = Category.CLIENT,
                    Date = new DateTime(2025, 3, 3),
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now.AddMinutes(105),
                    Break = 47,
                    Description = "Bezig gehouden met CLIENT XYZ"
                },
                new()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    AdminActivity = adminActivities[1],
                    Category = Category.PROJECT,
                    Date = new DateTime(2025, 2, 27),
                    Duration = 72,
                    Description = "Bezig gehouden met PROJECT XYZ"
                },
                new()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    AdminActivity = adminActivities[2],
                    Category = Category.LEARN,
                    Date = new DateTime(2025, 2, 25),
                    Duration = 95,
                    Description = "Bezig gehouden met LEARN XYZ"
                }
            };

            if (collection.CountDocuments(FilterDefinition<DetachedTimeEntry>.Empty) <= 0)
                collection.InsertMany(detachedTimeEntries);
        }
    }
}