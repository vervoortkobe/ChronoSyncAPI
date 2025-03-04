using Application.Interfaces;
using Domain.Model.Activities;
using Infrastructure.Contexts;

namespace Infrastructure.Repositories;

public class AdminActivityRepository : GenericRepository<AdminActivity>, IAdminActivityRepository
{
    public AdminActivityRepository(XylosContext context)
        : base(context.Database, "AdminActivities")
    {
    }


}
