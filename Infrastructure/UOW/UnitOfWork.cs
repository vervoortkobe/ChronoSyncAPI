using Application.Interfaces;
using Infrastructure.Contexts;

namespace Infrastructure.UOW;

public class UnitOfWork(
       XylosContext ctxt,
       IActivityRepository activityRepository,
       IAdminActivityRepository adminActivityRepository,
       IDetachedTimeEntryRepository detachedTimeEntryRepository,
       ITimeEntryRepository timeEntryRepository,
       IXylosUserRepository xylosUserRepository)
       : IUnitOfWork
{
    public IActivityRepository ActivityRepository => activityRepository;
    public IAdminActivityRepository AdminActivityRepository => adminActivityRepository;
    public IDetachedTimeEntryRepository DetachedTimeEntryRepository => detachedTimeEntryRepository;
    public ITimeEntryRepository TimeEntryRepository => timeEntryRepository;
    public IXylosUserRepository XylosUserRepository => xylosUserRepository;
    public async Task Commit()
    {
        //await ctxt.SaveChangesAsync();
        await Task.CompletedTask;
    }
}