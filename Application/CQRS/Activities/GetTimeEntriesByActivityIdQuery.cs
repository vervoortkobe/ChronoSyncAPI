using Application.CQRS.TimeEntries;
using Application.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;
using MongoDB.Bson;

namespace Application.CQRS.Activities;

public class GetTimeEntriesByActivityIdQuery : IRequest<IEnumerable<TimeEntryDTO>>
{
    public required string ActivityId { get; init; }
}

public class GetTimeEntriesByActivityIdQueryValidator : AbstractValidator<GetTimeEntriesByActivityIdQuery>
{
    public GetTimeEntriesByActivityIdQueryValidator()
    {
        RuleFor(query => query.ActivityId)
            .NotNull()
            .WithMessage("ActivityId cannot be null");
    }
}

public class GetTimeEntriesByActivityIdQueryHandler(IUnitOfWork uow, IMapper mapper) : IRequestHandler<GetTimeEntriesByActivityIdQuery, IEnumerable<TimeEntryDTO>>
{
    public async Task<IEnumerable<TimeEntryDTO>> Handle(GetTimeEntriesByActivityIdQuery request, CancellationToken cancellationToken)
    {
        return mapper.Map<IEnumerable<TimeEntryDTO>>(await uow.TimeEntryRepository.Find(o => o.Activity.Id == request.ActivityId));
    }
}
