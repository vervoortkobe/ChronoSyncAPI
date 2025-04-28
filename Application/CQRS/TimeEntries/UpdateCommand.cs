using Application.Exceptions;
using Application.Interfaces;
using AutoMapper;
using Domain.Model.Activities;
using Domain.Model.TimeEntries;
using FluentValidation;
using MediatR;

namespace Application.CQRS.TimeEntries;

public class UpdateCommand : IRequest<TimeEntryDTO>
{
    public required string ActivityId { get; init; }
    public required string TimeEntryId { get; init; }
    public required TimeEntryDTO TimeEntry { get; init; }
}

public class UpdateCommandValidator : AbstractValidator<UpdateCommand>
{
    public UpdateCommandValidator(IUnitOfWork uow)
    {
        RuleFor(x => x.ActivityId)
            .NotNull()
            .WithMessage("ActivityId cannot be empty");

        RuleFor(x => x.TimeEntryId)
            .NotNull()
            .WithMessage("TimeEntryId cannot be empty");

        RuleFor(x => x.TimeEntryId)
            .MustAsync(async (command, id, cancellation) =>
            {
                var timeEntry = await uow.TimeEntryRepository.GetById(id);
                return timeEntry != null && timeEntry.Activity.Id == command.ActivityId;
            })
            .WithMessage("The specified TimeEntry does not exist or does not match the ActivityId");

        RuleFor(x => x.TimeEntry)
            .Must((command, timeEntry, cancellation) =>
            {
                return timeEntry.Id == command.TimeEntryId;
            })
            .WithMessage("The specified Id of the TimeEntry does not equal the submitted TimeEntry Id in the route");

        RuleFor(x => x.TimeEntry)
            .Must(x => (x.StartTime.HasValue && x.EndTime.HasValue) || x.Duration.HasValue)
            .WithMessage("TimeEntry must have StartTime and EndTime, or Duration");

        RuleFor(x => x.TimeEntry.Description)
            .NotNull()
            .NotEmpty()
            .WithMessage("Description cannot be empty");
    }
}

public class UpdateCommandHandler(IUnitOfWork uow, IMapper mapper) : IRequestHandler<UpdateCommand, TimeEntryDTO>
{
    public async Task<TimeEntryDTO> Handle(UpdateCommand request, CancellationToken cancellationToken)
    {
        TimeEntry? timeEntry = await uow.TimeEntryRepository.GetById(request.TimeEntryId);
        if (timeEntry == null)
            throw new RelationNotFoundException($"The TimeEntry with id {request.TimeEntryId} doesn't exist.");

        var activity = await uow.ActivityRepository.GetById(request.ActivityId);
        if (activity == null || activity.Id != request.ActivityId)
            throw new RelationNotFoundException($"The related Activity with id {request.ActivityId} doesn't exist or is not related to the provided TimeEntry with id {request.TimeEntryId}.");

        request.TimeEntry.Activity = activity;

        if (timeEntry.EndTime != null && timeEntry.StartTime != null && timeEntry.Break != null)
            activity.CalculatedMinutesSpent -= ((int?)(timeEntry.EndTime - timeEntry.StartTime).Value.TotalMinutes) - timeEntry.Break;
        else
            activity.CalculatedMinutesSpent -= timeEntry.Duration;

        if (request.TimeEntry.EndTime != null && request.TimeEntry.StartTime != null && request.TimeEntry.Break != null)
            activity!.CalculatedMinutesSpent += ((int?)(request.TimeEntry.EndTime - request.TimeEntry.StartTime).Value.TotalMinutes) - request.TimeEntry.Break;
        else
            activity!.CalculatedMinutesSpent += request.TimeEntry.Duration!;

        await uow.ActivityRepository.Update(request.ActivityId, activity);

        await uow.TimeEntryRepository.Update(request.TimeEntry.Id!, mapper.Map<TimeEntry>(request.TimeEntry));

        return request.TimeEntry;
    }
}
