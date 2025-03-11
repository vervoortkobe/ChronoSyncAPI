using Application.CQRS.DetachedTimeEntries;
using Application.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;
using MongoDB.Bson;

namespace Application.CQRS.AdminActivities;

public class GetDetachedTimeEntriesByActivityIdQuery : IRequest<IEnumerable<DetachedTimeEntryDTO>>
{
    public required string ActivityId { get; init; }
}

public class GetDetachedTimeEntriesByActivityIdQueryValidator : AbstractValidator<GetDetachedTimeEntriesByActivityIdQuery>
{
    public GetDetachedTimeEntriesByActivityIdQueryValidator()
    {
        RuleFor(query => query.ActivityId)
            .NotNull()
            .WithMessage("ActivityId cannot be null");
    }
}

public class GetDetachedTimeEntriesByActivityIdQueryHandler(IUnitOfWork uow, IMapper mapper) : IRequestHandler<GetDetachedTimeEntriesByActivityIdQuery, IEnumerable<DetachedTimeEntryDTO>>
{
    public async Task<IEnumerable<DetachedTimeEntryDTO>> Handle(GetDetachedTimeEntriesByActivityIdQuery request, CancellationToken cancellationToken)
    {
        return mapper.Map<IEnumerable<DetachedTimeEntryDTO>>(await uow.DetachedTimeEntryRepository.Find(o => o.AdminActivity.Id == request.ActivityId));
    }
}
