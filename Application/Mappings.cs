using Application.CQRS.TimeEntries.DTO;
using Application.CQRS.Users.DTO;
using AutoMapper;
using Domain.Model.Activities;
using Domain.Model.TimeEntries;
using Domain.Model.Users;

namespace Application;

public class Mappings : Profile
{
    public Mappings()
    {
        CreateMap<Activity, GetActivityDTO>();
        CreateMap<AdminActivity, GetAdminActivityDTO>();
        CreateMap<DetachedTimeEntry, GetDetachedTimeEntryDTO>();
        CreateMap<TimeEntry, GetTimeEntryDTO>();
        CreateMap<XylosUser, GetXylosUserDTO>();
    }
}