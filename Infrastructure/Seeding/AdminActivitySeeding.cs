using Domain.Model.Activities;
using Domain.Model.TimeEntries;
using Domain.Model.Users;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Infrastructure.Seeding
{
    public static class AdminAcitvitySeeding
    {
        public static void Seed(IMongoDatabase database, List<XylosUser> users)
        {
            var collection = database.GetCollection<BaseActivity>("Activities");

            var activities = new List<AdminActivity>
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

            var filter = Builders<BaseActivity>.Filter.Eq("_t", nameof(AdminActivity));
            if (collection.CountDocuments(filter) == 0)
                collection.InsertMany(activities);

            DetachedTimeEntrySeeding.Seed(database, activities);
        }
    }
}