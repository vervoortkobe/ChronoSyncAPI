using Application.Interfaces;
using Infrastructure.Contexts;
using Infrastructure.Repositories;
using Infrastructure.UOW;

namespace Infrastructure.Extensions;

public static class Registrator
{
    public static IServiceCollection RegisterInfrastructure(this IServiceCollection services)
    {
        services.RegisterDbContext();
        services.RegisterRepositories();
        return services;
    }

    public static IServiceCollection RegisterDbContext(this IServiceCollection services)
    {
        services.AddSingleton(new XylosContext(Environment.GetEnvironmentVariable("CHRONOSYNC_MONGODB_CONNSTR", EnvironmentVariableTarget.User)));
        return services;
    }

    public static IServiceCollection RegisterRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IActivityRepository, ActivityRepository>();
        services.AddScoped<ITimeEntryRepository, TimeEntryRepository>();
        services.AddScoped<IXylosUserRepository, XylosUserRepository>();
        return services;
    }
}
