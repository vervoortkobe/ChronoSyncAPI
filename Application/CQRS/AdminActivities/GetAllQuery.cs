using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.CQRS.AdminActivities;

public class GetAllQuery : IRequest<IEnumerable<AdminActivityDTO>>
{
    public int PageNr { get; init; }
    public int PageSize { get; init; }
}

public class GetAllQueryHandler(IUnitOfWork uow, IMapper mapper) : IRequestHandler<GetAllQuery, IEnumerable<AdminActivityDTO>>
{
    public async Task<IEnumerable<AdminActivityDTO>> Handle(GetAllQuery request, CancellationToken cancellationToken)
    {
        return mapper.Map<IEnumerable<AdminActivityDTO>>(await uow.ActivityRepository.GetAll(request.PageNr, request.PageSize));
    }
}