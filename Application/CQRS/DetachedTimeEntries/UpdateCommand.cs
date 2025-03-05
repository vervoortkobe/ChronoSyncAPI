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
                var timeEntry = await uow.DetachedTimeEntryRepository.GetById(id);
                return timeEntry != null && timeEntry.Activity.Id == command.ActivityId;
            })
            .WithMessage("The specified TimeEntry does not exist or does not match the ActivityId");

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
        await uow.DetachedTimeEntryRepository.Update(request.DetachedTimeEntry.Id!, mapper.Map<DetachedTimeEntry>(request.DetachedTimeEntry));
        return request.DetachedTimeEntry;
    }
}