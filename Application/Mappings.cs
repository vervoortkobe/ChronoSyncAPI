using Application.CQRS.Activities;
using Application.CQRS.AdminActivities;
using Application.CQRS.DetachedTimeEntries;
using Application.CQRS.TimeEntries;
using Application.CQRS.Users;
using AutoMapper;
using Domain.Model.Activities;
using Domain.Model.TimeEntries;
using Domain.Model.Users;

public class Mappings : Profile
{
    public Mappings()
    {
        CreateMap<Activity, ActivityDTO>();
        CreateMap<AdminActivity, AdminActivityDTO>();
        CreateMap<TimeEntry, TimeEntryDTO>();
        CreateMap<DetachedTimeEntry, DetachedTimeEntryDTO>();
        CreateMap<XylosUser, XylosUserDTO>();
    }
}
