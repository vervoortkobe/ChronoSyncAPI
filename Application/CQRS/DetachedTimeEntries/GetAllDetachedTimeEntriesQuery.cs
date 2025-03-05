using Application.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Application.CQRS.DetachedTimeEntries;

public class GetAllDetachedTimeEntriesQuery : IRequest<IEnumerable<GetDetachedTimeEntryDTO>>
{
}

public class GetAllDetachedTimeEntriesQueryValidator : AbstractValidator<GetAllDetachedTimeEntriesQuery>
{
    public GetAllDetachedTimeEntriesQueryValidator()
    {
    }
}

public class GetAllDetachedTimeEntriesQueryHandler(IUnitOfWork uow, IMapper mapper) : IRequestHandler<GetAllDetachedTimeEntriesQuery, IEnumerable<GetDetachedTimeEntryDTO>>
{
    public async Task<IEnumerable<GetDetachedTimeEntryDTO>> Handle(GetAllDetachedTimeEntriesQuery request, CancellationToken cancellationToken)
    {
        return mapper.Map<IEnumerable<GetDetachedTimeEntryDTO>>(await uow.DetachedTimeEntryRepository.GetAll()!);
    }
}