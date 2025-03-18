using Application.Interfaces;
using AutoMapper;
using Domain.Model.TimeEntries;
using FluentValidation;
using MediatR;

namespace Application.CQRS.DetachedTimeEntries;

public class AddCommand : IRequest<DetachedTimeEntryDTO>
{
    public required string ActivityId { get; init; }
    public required DetachedTimeEntryDTO DetachedTimeEntry { get; init; }
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

public class AddCommandHandler(IUnitOfWork uow, IMapper mapper) : IRequestHandler<AddCommand, DetachedTimeEntryDTO>
{
    public async Task<DetachedTimeEntryDTO> Handle(AddCommand request, CancellationToken cancellationToken)
    {
        request.DetachedTimeEntry.AdminActivity = await uow.AdminActivityRepository.GetById(request.ActivityId);
        await uow.DetachedTimeEntryRepository.Create(mapper.Map<DetachedTimeEntry>(request.DetachedTimeEntry));
        return request.DetachedTimeEntry;
    }
}