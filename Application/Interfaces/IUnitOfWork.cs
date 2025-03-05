namespace Application.Interfaces;

public interface IUnitOfWork
{
    public IActivityRepository ActivityRepository { get; }
    public IAdminActivityRepository AdminActivityRepository { get; }
    public IDetachedTimeEntryRepository DetachedTimeEntryRepository { get; }
    public ITimeEntryRepository TimeEntryRepository { get; }
    public IXylosUserRepository XylosUserRepository { get; }
}