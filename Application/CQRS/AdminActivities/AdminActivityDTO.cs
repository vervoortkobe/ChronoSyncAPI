using Domain.Model.Users;

namespace Application.CQRS.AdminActivities;

public class AdminActivityDTO
{
    public required string Id { get; set; }
    public required XylosUser XylosUser { get; set; }
}