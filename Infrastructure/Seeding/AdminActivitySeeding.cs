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
            var collAdminActivities = database.GetCollection<AdminActivity>("AdminActivities");

            if (collAdminActivities.CountDocuments(FilterDefinition<AdminActivity>.Empty) > 0)
                return;

            var adminActivities = new List<AdminActivity>
            {
                new AdminActivity
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    XylosUser = users[0]
                },
                new AdminActivity
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    XylosUser = users[1]
                },
                new AdminActivity
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    XylosUser = users[2]
                }
            };

            collAdminActivities.InsertMany(adminActivities);
        }
    }
}