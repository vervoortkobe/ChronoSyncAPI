using Application.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Application.CQRS.DetachedTimeEntries;

public class GetDetachedTimeEntryByIdQuery : IRequest<GetDetachedTimeEntryDTO>
{
    public required string Id { get; init; }
}

public class GetDetachedTimeEntryByIdQueryValidator : AbstractValidator<GetDetachedTimeEntryByIdQuery>
{
    public GetDetachedTimeEntryByIdQueryValidator()
    {
        RuleFor(query => query.Id)
            .NotNull()
            .WithMessage("Id cannot be null");
    }
}

public class GetDetachedTimeEntryByIdQueryHandler(IUnitOfWork uow, IMapper mapper) : IRequestHandler<GetDetachedTimeEntryByIdQuery, GetDetachedTimeEntryDTO>
{
    public async Task<GetDetachedTimeEntryDTO> Handle(GetDetachedTimeEntryByIdQuery request, CancellationToken cancellationToken)
    {
        return mapper.Map<GetDetachedTimeEntryDTO>(await uow.DetachedTimeEntryRepository.GetById(request.Id)!);
    }
}