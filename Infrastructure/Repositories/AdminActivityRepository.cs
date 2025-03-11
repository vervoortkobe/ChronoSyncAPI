using Application.Interfaces;
using Domain.Model.Activities;
using Infrastructure.Contexts;

namespace Infrastructure.Repositories;

public class AdminActivityRepository : GenericRepository<Activity>, IAdminActivityRepository
{
    public AdminActivityRepository(XylosContext context)
        : base(context.Database, "AdminActivities")
    {
    }


}
