using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.CQRS.TimeEntries;

public class GetAllQuery : IRequest<IEnumerable<TimeEntryDTO>>
{
    public int PageNr { get; init; }
    public int PageSize { get; init; }
}

public class GetAllQueryHandler(IUnitOfWork uow, IMapper mapper) : IRequestHandler<GetAllQuery, IEnumerable<TimeEntryDTO>>
{
    public async Task<IEnumerable<TimeEntryDTO>> Handle(GetAllQuery request, CancellationToken cancellationToken)
    {
        return mapper.Map<IEnumerable<TimeEntryDTO>>(await uow.TimeEntryRepository.GetAll(request.PageNr, request.PageSize));
    }
}