using Application.Interfaces;
using Infrastructure.Contexts;

namespace Infrastructure.UOW;

public class UnitOfWork(
       XylosContext ctxt,
       IXylosUserRepository xylosUserRepository)
       : IUnitOfWork
{
    public IXylosUserRepository XylosUserRepository => xylosUserRepository;
    public async Task Commit()
    {
        //await ctxt.SaveChangesAsync();
        await Task.CompletedTask;
    }
}