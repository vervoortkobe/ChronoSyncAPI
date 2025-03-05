using Domain.Model.Users;

namespace Application.CQRS.Users.DTO;

public class GetXylosUserDTO
{
    public required string Id { get; set; }
    public required string UPN { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required Function Function { get; set; }
    public required string Picture { get; set; }
}
