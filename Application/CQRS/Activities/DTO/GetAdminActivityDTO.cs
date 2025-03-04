using Domain.Model.Users;

namespace Domain.Model.Activities;

public class GetAdminActivityDTO
{
    public required string Id { get; set; }
    public required XylosUser XylosUser { get; set; }
}