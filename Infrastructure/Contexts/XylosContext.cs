using Domain.Model.Activities;
using Domain.Model.TimeEntries;
using Domain.Model.Users;
using Infrastructure.Configuration;
using Infrastructure.Seeding;
using MongoDB.Driver;

namespace Infrastructure.Contexts;

public class XylosContext
{
    public IMongoDatabase Database { get; }

    public XylosContext(string? connectionString)
    {
        if (string.IsNullOrEmpty(connectionString))
            throw new InvalidOperationException("No MongoDB connectionString found in environment variables!");

        var mongoUrl = new MongoUrl(connectionString);
        var client = new MongoClient(mongoUrl);
        Database = client.GetDatabase(mongoUrl.DatabaseName);

        BaseActivityConfiguration.Configure();
        ActivityConfiguration.Configure();
        AdminActivityConfiguration.Configure();
        BaseTimeEntryConfiguration.Configure();
        DetachedTimeEntryConfiguration.Configure();
        TimeEntryConfiguration.Configure();
        XylosUserConfiguration.Configure();

        XylosUserSeeding.Seed(Database);
    }

    public IMongoCollection<Activity> Activities => Database.GetCollection<Activity>("Activities");
    public IMongoCollection<TimeEntry> TimeEntries => Database.GetCollection<TimeEntry>("TimeEntries");
    public IMongoCollection<XylosUser> XylosUsers => Database.GetCollection<XylosUser>("XylosUsers");
}
