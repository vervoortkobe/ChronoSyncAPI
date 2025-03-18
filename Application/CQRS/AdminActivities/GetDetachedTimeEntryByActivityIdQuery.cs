using Application.CQRS.DetachedTimeEntries;
using Application.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Application.CQRS.AdminActivities;

public class GetDetachedTimeEntryByActivityIdQuery : IRequest<DetachedTimeEntryDTO>
{
    public required string ActivityId { get; init; }
    public required string TimeEntryId { get; init; }
}

public class GetDetachedTimeEntryByActivityIdQueryValidator : AbstractValidator<GetDetachedTimeEntryByActivityIdQuery>
{
    public GetDetachedTimeEntryByActivityIdQueryValidator()
    {
        RuleFor(query => query.ActivityId)
            .NotNull()
            .WithMessage("ActivityId cannot be null");

        RuleFor(query => query.TimeEntryId)
            .NotNull()
            .WithMessage("TimeEntryId cannot be null");
    }
}

public class GetDetachedTimeEntryByActivityIdQueryHandler(IUnitOfWork uow, IMapper mapper) : IRequestHandler<GetDetachedTimeEntryByActivityIdQuery, DetachedTimeEntryDTO>
{
    public async Task<DetachedTimeEntryDTO> Handle(GetDetachedTimeEntryByActivityIdQuery request, CancellationToken cancellationToken)
    {
        var detachedTimeEntry = await uow.DetachedTimeEntryRepository.GetById(request.TimeEntryId);
        if (detachedTimeEntry != null && detachedTimeEntry.AdminActivity.Id == request.ActivityId)
            return mapper.Map<DetachedTimeEntryDTO>(detachedTimeEntry);

        return new DetachedTimeEntryDTO() { Category = 0, Date = new DateTime(), Description = "" };
    }
}
