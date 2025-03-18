using Application.Interfaces;
using AutoMapper;
using Domain.Model.TimeEntries;
using FluentValidation;
using MediatR;

namespace Application.CQRS.TimeEntries;

public class AddCommand : IRequest<TimeEntryDTO>
{
    public required string ActivityId { get; init; }
    public required TimeEntryDTO TimeEntry { get; init; }
}

public class AddCommandValidator : AbstractValidator<AddCommand>
{
    public AddCommandValidator(IUnitOfWork uow)
    {
        RuleFor(x => x.ActivityId)
            .NotNull()
            .WithMessage("ActivityId cannot be empty");

        RuleFor(x => x.ActivityId)
            .MustAsync(async (id, cancellation) =>
            {
                var activity = await uow.ActivityRepository.GetById(id);
                return (activity != null);
            })
            .WithMessage("The specified activity does not exist");

        RuleFor(x => x.TimeEntry.Date)
            .NotNull()
            .NotEmpty()
            .WithMessage("Date cannot be empty");

        RuleFor(x => x.TimeEntry)
            .Must(x => (x.StartTime.HasValue && x.EndTime.HasValue) || x.Duration.HasValue)
            .WithMessage("TimeEntry must have StartTime and EndTime, or Duration");

        RuleFor(x => x.TimeEntry.Description)
            .NotNull()
            .NotEmpty()
            .WithMessage("Description cannot be empty");
    }
}

public class AddCommandHandler(IUnitOfWork uow, IMapper mapper) : IRequestHandler<AddCommand, TimeEntryDTO>
{
    public async Task<TimeEntryDTO> Handle(AddCommand request, CancellationToken cancellationToken)
    {
        request.TimeEntry.Activity = await uow.ActivityRepository.GetById(request.ActivityId);
        await uow.TimeEntryRepository.Create(mapper.Map<TimeEntry>(request.TimeEntry));
        return request.TimeEntry;
    }
}