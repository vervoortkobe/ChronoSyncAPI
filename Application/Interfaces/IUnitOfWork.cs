namespace Application.Interfaces;

public interface IUnitOfWork
{
    public ITimeEntryRepository TimeEntryRepository { get; }
    public IXylosUserRepository XylosUserRepository { get; }

    Task Commit();
}