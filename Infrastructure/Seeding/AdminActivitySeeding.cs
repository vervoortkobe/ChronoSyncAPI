using Domain.Model.Activities;
using Domain.Model.Users;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Infrastructure.Seeding
{
    public static class AdminAcitvitySeeding
    {
        public static void Seed(IMongoDatabase database, List<XylosUser> users)
        {
            var collection = database.GetCollection<AdminActivity>("Activities");

            var adminActivities = new List<AdminActivity>
            {
                new()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    XylosUser = users[0]
                },
                new()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    XylosUser = users[1]
                },
                new()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    XylosUser = users[2]
                }
            };

            if (collection.CountDocuments(FilterDefinition<AdminActivity>.Empty) <= 0)
                collection.InsertMany(adminActivities);

            DetachedTimeEntrySeeding.Seed(database, adminActivities);
        }
    }
}