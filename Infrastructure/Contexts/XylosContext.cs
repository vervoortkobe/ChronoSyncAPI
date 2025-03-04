using Domain.Model.Activities;
using Domain.Model.TimeEntries;
using Domain.Model.Users;
using Infrastructure.Configuration;
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

        ActivityConfiguration.Configure();
        TimeEntryConfiguration.Configure();
        XylosUserConfiguration.Configure();
    }

    public IMongoCollection<Activity> Activities => Database.GetCollection<Activity>("Activities");
    public IMongoCollection<AdminActivity> AdminActivities => Database.GetCollection<AdminActivity>("AdminActivities");
    public IMongoCollection<DetachedTimeEntry> DetachedTimeEntries => Database.GetCollection<DetachedTimeEntry>("DetachedTimeEntries");
    public IMongoCollection<Organisation> Organisations => Database.GetCollection<Organisation>("Organisations");
    public IMongoCollection<Project> Projects => Database.GetCollection<Project>("Projects");
    public IMongoCollection<TimeEntry> TimeEntries => Database.GetCollection<TimeEntry>("TimeEntries");
    public IMongoCollection<XylosUser> XylosUsers => Database.GetCollection<XylosUser>("XylosUsers");
}
