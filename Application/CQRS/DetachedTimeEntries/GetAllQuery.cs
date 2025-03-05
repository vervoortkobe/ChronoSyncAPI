using Application.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Application.CQRS.DetachedTimeEntries;

public class GetAllQuery : IRequest<IEnumerable<DetachedTimeEntryDTO>>
{
}

public class GetAllQueryValidator : AbstractValidator<GetAllQuery>
{
    public GetAllQueryValidator()
    {
    }
}

public class GetAllQueryHandler(IUnitOfWork uow, IMapper mapper) : IRequestHandler<GetAllQuery, IEnumerable<DetachedTimeEntryDTO>>
{
    public async Task<IEnumerable<DetachedTimeEntryDTO>> Handle(GetAllQuery request, CancellationToken cancellationToken)
    {
        return mapper.Map<IEnumerable<DetachedTimeEntryDTO>>(await uow.DetachedTimeEntryRepository.GetAll()!);
    }
}