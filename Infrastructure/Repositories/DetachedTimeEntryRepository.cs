using Application.Interfaces;
using Domain.Model.TimeEntries;
using Infrastructure.Contexts;

namespace Infrastructure.Repositories;

public class DetachedTimeEntryRepository : GenericRepository<DetachedTimeEntry>, IDetachedTimeEntryRepository
{
    public DetachedTimeEntryRepository(XylosContext context)
        : base(context.Database, "DetachedTimeEntries")
    {
    }


}
