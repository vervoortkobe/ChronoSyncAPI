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
        CreateMap<BaseActivity, ActivityDTO>()
            .Include<Activity, ActivityDTO>();
        CreateMap<Activity, ActivityDTO>();

        CreateMap<BaseActivity, AdminActivityDTO>()
            .Include<AdminActivity, AdminActivityDTO>();
        CreateMap<AdminActivity, AdminActivityDTO>();

        CreateMap<BaseTimeEntry, TimeEntryDTO>()
            .Include<TimeEntry, TimeEntryDTO>();
        CreateMap<TimeEntry, TimeEntryDTO>();

        CreateMap<BaseTimeEntry, DetachedTimeEntryDTO>()
            .Include<DetachedTimeEntry, DetachedTimeEntryDTO>();
        CreateMap<DetachedTimeEntry, DetachedTimeEntryDTO>();

        CreateMap<XylosUser, XylosUserDTO>();
    }
}
