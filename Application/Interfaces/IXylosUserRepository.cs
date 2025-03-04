using Domain.Model.Activities;
using Domain.Model.Users;

namespace Application.Interfaces;

public interface IXylosUserRepository : IGenericRepository<XylosUser>
{
    Task<XylosUser?> GetUserByUPN(string upn);
}