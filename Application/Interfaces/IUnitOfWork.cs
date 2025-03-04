namespace Application.Interfaces;

public interface IUnitOfWork
{
    public IXylosUserRepository XylosUserRepository { get; }

    Task Commit();
}