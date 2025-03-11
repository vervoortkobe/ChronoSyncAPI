using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.CQRS.DetachedTimeEntries;

public class GetAllQuery : IRequest<IEnumerable<DetachedTimeEntryDTO>>
{
    public int PageNr { get; init; }
    public int PageSize { get; init; }
}

public class GetAllQueryHandler(IUnitOfWork uow, IMapper mapper) : IRequestHandler<GetAllQuery, IEnumerable<DetachedTimeEntryDTO>>
{
    public async Task<IEnumerable<DetachedTimeEntryDTO>> Handle(GetAllQuery request, CancellationToken cancellationToken)
    {
        return mapper.Map<IEnumerable<DetachedTimeEntryDTO>>(await uow.DetachedTimeEntryRepository.GetAll(request.PageNr, request.PageSize));
    }
}