using Domain.Model.Users;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Infrastructure.Seeding
{
    public static class XylosUserSeeding
    {
        public static void Seed(IMongoDatabase database)
        {
            var collection = database.GetCollection<XylosUser>("XylosUsers");

            var users = new List<XylosUser>
            {
                new()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    UPN = "john.doe@xylos.com",
                    FirstName = "John",
                    LastName = "Doe",
                    Function = Function.SERVICEDESK,
                    Picture = "https://example.com/john.jpg"
                },
                new()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    UPN = "jane.smith@xylos.com",
                    FirstName = "Jane",
                    LastName = "Smith",
                    Function = Function.ADMINISTRATOR,
                    Picture = "https://example.com/jane.jpg"
                },
                new()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    UPN = "jan.rob@xylos.com",
                    FirstName = "Jan",
                    LastName = "Rob",
                    Function = Function.TEAMLEAD,
                    Picture = "https://example.com/jan.jpg"
                }
            };

            if (collection.CountDocuments(FilterDefinition<XylosUser>.Empty) <= 0) 
                collection.InsertMany(users);

            AdminAcitvitySeeding.Seed(database, users);
            ActivitySeeding.Seed(database, users);
        }
    }
}