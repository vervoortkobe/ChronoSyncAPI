using Domain.Model.Activities;
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

            if (collection.CountDocuments(FilterDefinition<XylosUser>.Empty) > 0) 
                return;

            var users = new List<XylosUser>
            {
                new XylosUser
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    UPN = "user1@xylos.com",
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john.doe@xylos.com",
                    Function = Function.SERVICEDESK,
                    Picture = "https://example.com/john.jpg"
                },
                new XylosUser
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    UPN = "user2@xylos.com",
                    FirstName = "Jane",
                    LastName = "Smith",
                    Email = "jane.smith@xylos.com",
                    Function = Function.ADMINISTRATOR,
                    Picture = "https://example.com/jane.jpg"
                },
            };

            collection.InsertMany(users);
        }
    }
}