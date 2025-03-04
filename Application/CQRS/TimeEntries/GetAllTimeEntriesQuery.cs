using Application.CQRS.TimeEntries.DTO;
using Application.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Application.CQRS.Users;

public class GetAllTimeEntriesQuery : IRequest<IEnumerable<GetTimeEntryDTO>>
{
}

public class GetAllTimeEntriesQueryValidator : AbstractValidator<GetAllTimeEntriesQuery>
{
    public GetAllTimeEntriesQueryValidator()
    {
    }
}

public class GetAllTimeEntriesQueryHandler(IUnitOfWork uow, IMapper mapper) : IRequestHandler<GetAllTimeEntriesQuery, IEnumerable<GetTimeEntryDTO>>
{
    public async Task<IEnumerable<GetTimeEntryDTO>> Handle(GetAllTimeEntriesQuery request, CancellationToken cancellationToken)
    {
        return mapper.Map<IEnumerable<GetTimeEntryDTO>>(await uow.TimeEntryRepository.GetAll()!);
    }
}