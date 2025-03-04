using Application.Interfaces;
using Domain.Model.Users;
using Infrastructure.Contexts;
using MongoDB.Driver;

namespace Infrastructure.Repositories;

public class XylosUserRepository : GenericRepository<XylosUser>, IXylosUserRepository
{
    public XylosUserRepository(XylosContext context)
        : base(context.Database, "XylosUsers")
    {
    }

    public async Task<XylosUser?> GetUserByUPN(string upn)
    {
        var filter = Builders<XylosUser>.Filter.Eq(u => u.UPN, upn);
        return await collection.Find(filter).FirstOrDefaultAsync();
    }
}
