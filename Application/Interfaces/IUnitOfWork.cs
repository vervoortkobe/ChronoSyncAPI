namespace Application.Interfaces;

public interface IUnitOfWork
{
    public IActivityRepository ActivityRepository { get; }
    public ITimeEntryRepository TimeEntryRepository { get; }
    public IXylosUserRepository XylosUserRepository { get; }

    Task Commit();
}