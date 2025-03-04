using Application.Interfaces;
using Infrastructure.Contexts;

namespace Infrastructure.UOW;

public class UnitOfWork(
       XylosContext ctxt,
       ITimeEntryRepository timeEntryRepository,
       IXylosUserRepository xylosUserRepository)
       : IUnitOfWork
{
    public ITimeEntryRepository TimeEntryRepository => timeEntryRepository;
    public IXylosUserRepository XylosUserRepository => xylosUserRepository;
    public async Task Commit()
    {
        //await ctxt.SaveChangesAsync();
        await Task.CompletedTask;
    }
}