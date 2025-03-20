using Application.CQRS.TimeEntries;
using Application.Interfaces;
using AutoMapper;
using Domain.Model.TimeEntries;
using FluentValidation;
using MediatR;

namespace Application.CQRS.DetachedTimeEntries;

public class UpdateCommand : IRequest<DetachedTimeEntryDTO>
{
    public required string ActivityId { get; init; }
    public required string TimeEntryId { get; init; }
    public required DetachedTimeEntryDTO DetachedTimeEntry { get; init; }
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

        RuleFor(x => x.DetachedTimeEntry)
            .Must((command, detachedTimeEntry, cancellation) =>
            {
                return detachedTimeEntry.Id == command.TimeEntryId;
            })
            .WithMessage("The specified Id of the DetachedTimeEntry does not equal the submitted DetachedTimeEntry Id in the route");

        RuleFor(x => x.DetachedTimeEntry.Category)
            .NotNull()
            .WithMessage("Category cannot be empty");

        RuleFor(x => x.DetachedTimeEntry.Date)
            .NotNull()
            .WithMessage("Date cannot be empty");

        RuleFor(x => x.DetachedTimeEntry)
            .Must(x => (x.StartTime.HasValue && x.EndTime.HasValue) || x.Duration.HasValue)
            .WithMessage("TimeEntry must have StartTime and EndTime, or Duration");

        RuleFor(x => x.DetachedTimeEntry.Description)
            .NotNull()
            .NotEmpty()
            .WithMessage("Description cannot be empty");
    }
}

public class UpdateCommandHandler(IUnitOfWork uow, IMapper mapper) : IRequestHandler<UpdateCommand, DetachedTimeEntryDTO>
{
    public async Task<DetachedTimeEntryDTO> Handle(UpdateCommand request, CancellationToken cancellationToken)
    {
        var adminActivity = await uow.AdminActivityRepository.GetById(request.ActivityId);
        if (adminActivity != null && adminActivity.Id == request.ActivityId)
            request.DetachedTimeEntry.AdminActivity = adminActivity;

        await uow.DetachedTimeEntryRepository.Update(request.DetachedTimeEntry.Id!, mapper.Map<DetachedTimeEntry>(request.DetachedTimeEntry));
        return request.DetachedTimeEntry;
    }
}