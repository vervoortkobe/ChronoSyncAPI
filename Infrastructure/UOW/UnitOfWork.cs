using Application.Interfaces;

namespace Infrastructure.UOW;

public class UnitOfWork(
       IActivityRepository activityRepository,
       IAdminActivityRepository adminActivityRepository,
       IDetachedTimeEntryRepository detachedTimeEntryRepository,
       ITimeEntryRepository timeEntryRepository,
       IXylosUserRepository xylosUserRepository
    ) : IUnitOfWork
{
    public IActivityRepository ActivityRepository => activityRepository;
    public IAdminActivityRepository AdminActivityRepository => adminActivityRepository;
    public IDetachedTimeEntryRepository DetachedTimeEntryRepository => detachedTimeEntryRepository;
    public ITimeEntryRepository TimeEntryRepository => timeEntryRepository;
    public IXylosUserRepository XylosUserRepository => xylosUserRepository;
}