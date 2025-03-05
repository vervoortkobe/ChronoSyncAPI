using Application.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Application.CQRS.TimeEntries;

public class GetAllQuery : IRequest<IEnumerable<TimeEntryDTO>>
{
}

public class GetAllQueryValidator : AbstractValidator<GetAllQuery>
{
    public GetAllQueryValidator()
    {
    }
}

public class GetAllQueryHandler(IUnitOfWork uow, IMapper mapper) : IRequestHandler<GetAllQuery, IEnumerable<TimeEntryDTO>>
{
    public async Task<IEnumerable<TimeEntryDTO>> Handle(GetAllQuery request, CancellationToken cancellationToken)
    {
        return mapper.Map<IEnumerable<TimeEntryDTO>>(await uow.TimeEntryRepository.GetAll()!);
    }
}