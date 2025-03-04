using Application.Interfaces;
using Domain.Model.Activities;
using Infrastructure.Contexts;

namespace Infrastructure.Repositories;

public class ActivityRepository : GenericRepository<Activity>, IActivityRepository
{
    public ActivityRepository(XylosContext context)
        : base(context.Database, "Activities")
    {
    }


}
