using Application.CQRS.Users.DTO;
using AutoMapper;
using Domain.Model.Users;

namespace Application;

public class Mappings : Profile
{
    public Mappings()
    {
        CreateMap<XylosUser, GetXylosUserDTO>();
    }
}