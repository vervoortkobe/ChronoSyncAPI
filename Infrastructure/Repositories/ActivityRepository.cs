using Application.Interfaces;
using Domain.Model.Activities;
using Infrastructure.Contexts;

namespace Infrastructure.Repositories;

public class ActivityRepository : GenericRepository<BaseActivity>, IActivityRepository
{
    public ActivityRepository(XylosContext context)
        : base(context.Database, "Activities")
    {
    }


}
