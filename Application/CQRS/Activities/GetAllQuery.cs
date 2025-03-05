using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.CQRS.Activities;

public class GetAllQuery : IRequest<IEnumerable<ActivityDTO>>
{
    public int PageNr { get; set; }
    public int PageSize { get; set; }
}

public class GetAllQueryHandler(IUnitOfWork uow, IMapper mapper) : IRequestHandler<GetAllQuery, IEnumerable<ActivityDTO>>
{
    public async Task<IEnumerable<ActivityDTO>> Handle(GetAllQuery request, CancellationToken cancellationToken)
    {
        return mapper.Map<IEnumerable<ActivityDTO>>(await uow.ActivityRepository.GetAll(request.PageNr, request.PageSize));
    }
}