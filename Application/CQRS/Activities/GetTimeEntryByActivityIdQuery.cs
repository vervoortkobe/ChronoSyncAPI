using Application.CQRS.TimeEntries;
using Application.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Application.CQRS.Activities;

public class GetTimeEntryByActivityIdQuery : IRequest<TimeEntryDTO>
{
    public required string ActivityId { get; init; }
    public required string TimeEntryId { get; init; }
}

public class GetTimeEntryByActivityIdQueryValidator : AbstractValidator<GetTimeEntryByActivityIdQuery>
{
    public GetTimeEntryByActivityIdQueryValidator()
    {
        RuleFor(query => query.ActivityId)
            .NotNull()
            .WithMessage("ActivityId cannot be null");

        RuleFor(query => query.TimeEntryId)
            .NotNull()
            .WithMessage("TimeEntryId cannot be null");
    }
}

public class GetTimeEntryByActivityIdQueryHandler(IUnitOfWork uow, IMapper mapper) : IRequestHandler<GetTimeEntryByActivityIdQuery, TimeEntryDTO>
{
    public async Task<TimeEntryDTO> Handle(GetTimeEntryByActivityIdQuery request, CancellationToken cancellationToken)
    {
        var timeEntry = await uow.TimeEntryRepository.GetById(request.TimeEntryId);
        if (timeEntry != null && timeEntry.Activity.Id == request.ActivityId)
            return mapper.Map<TimeEntryDTO>(timeEntry);

        return new TimeEntryDTO() { Description = "" };
    }
}
