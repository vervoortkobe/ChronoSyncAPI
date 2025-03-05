using Application.Interfaces;

namespace Infrastructure.UOW;

public class UnitOfWork(
       IActivityRepository activityRepository,
       ITimeEntryRepository timeEntryRepository,
       IXylosUserRepository xylosUserRepository
    ) : IUnitOfWork
{
    public IActivityRepository ActivityRepository => activityRepository;
    public ITimeEntryRepository TimeEntryRepository => timeEntryRepository;
    public IXylosUserRepository XylosUserRepository => xylosUserRepository;
}