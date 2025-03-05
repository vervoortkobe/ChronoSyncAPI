using Application.Interfaces;
using Domain.Model.TimeEntries;
using Infrastructure.Contexts;

namespace Infrastructure.Repositories;

public class TimeEntryRepository : GenericRepository<BaseTimeEntry>, ITimeEntryRepository
{
    public TimeEntryRepository(XylosContext context)
        : base(context.Database, "TimeEntries")
    {
    }


}
