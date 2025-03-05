using Application.CQRS.DetachedTimeEntries;
using Application.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Application.CQRS.AdminActivities;

public class GetDetachedTimeEntriesByAdminActivityIdQuery : IRequest<IEnumerable<DetachedTimeEntryDTO>>
{
    public required string ActivityId { get; init; }
}

public class GetDetachedTimeEntriesByAdminActivityIdQueryValidator : AbstractValidator<GetDetachedTimeEntriesByAdminActivityIdQuery>
{
    public GetDetachedTimeEntriesByAdminActivityIdQueryValidator()
    {
        RuleFor(query => query.ActivityId)
            .NotNull()
            .WithMessage("ActivityId cannot be null");
    }
}

public class GetDetachedTimeEntriesByAdminActivityIdQueryHandler(IUnitOfWork uow, IMapper mapper) : IRequestHandler<GetDetachedTimeEntriesByAdminActivityIdQuery, IEnumerable<DetachedTimeEntryDTO>>
{
    public async Task<IEnumerable<DetachedTimeEntryDTO>> Handle(GetDetachedTimeEntriesByAdminActivityIdQuery request, CancellationToken cancellationToken)
    {
        return mapper.Map<IEnumerable<DetachedTimeEntryDTO>>(await uow.DetachedTimeEntryRepository.Find(o => o.Id == request.ActivityId));
    }
}
