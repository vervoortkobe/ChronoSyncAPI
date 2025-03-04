using Application.CQRS.TimeEntries.DTO;
using Application.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Application.CQRS.Users;

public class GetTimeEntryByIdQuery : IRequest<GetTimeEntryDTO>
{
    public required string Id { get; init; }
}

public class GetTimeEntryByIdQueryValidator : AbstractValidator<GetTimeEntryByIdQuery>
{
    public GetTimeEntryByIdQueryValidator()
    {
        RuleFor(query => query.Id)
            .NotNull()
            .WithMessage("Id cannot be null");
    }
}

public class GetTimeEntryByIdQueryHandler(IUnitOfWork uow, IMapper mapper) : IRequestHandler<GetTimeEntryByIdQuery, GetTimeEntryDTO>
{
    public async Task<GetTimeEntryDTO> Handle(GetTimeEntryByIdQuery request, CancellationToken cancellationToken)
    {
        return mapper.Map<GetTimeEntryDTO>(await uow.TimeEntryRepository.GetById(request.Id)!);
    }
}