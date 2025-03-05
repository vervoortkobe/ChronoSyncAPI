using Application.CQRS.Activities;
using Application.CQRS.AdminActivities;
using Application.CQRS.DetachedTimeEntries;
using Application.CQRS.TimeEntries;
using Application.CQRS.Users;
using AutoMapper;
using Domain.Model.Activities;
using Domain.Model.TimeEntries;
using Domain.Model.Users;

namespace Application;

public class Mappings : Profile
{
    public Mappings()
    {
        CreateMap<Activity, ActivityDTO>();
        CreateMap<AdminActivity, GetAdminActivityDTO>();
        CreateMap<DetachedTimeEntry, GetDetachedTimeEntryDTO>();
        CreateMap<TimeEntry, TimeEntryDTO>();
        CreateMap<XylosUser, XylosUserDTO>();
    }
}