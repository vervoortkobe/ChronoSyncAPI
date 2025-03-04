using Application.CQRS.TimeEntries.DTO;
using Application.CQRS.Users.DTO;
using AutoMapper;
using Domain.Model.TimeEntries;
using Domain.Model.Users;

namespace Application;

public class Mappings : Profile
{
    public Mappings()
    {
        CreateMap<TimeEntry, GetTimeEntryDTO>();
        CreateMap<XylosUser, GetXylosUserDTO>();
    }
}