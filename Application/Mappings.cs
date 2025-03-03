using AutoMapper;

namespace Application;

public class Mappings
{
    public Mappings()
    {
        CreateMap<InternalUser, GetUserDto>();
    }
}