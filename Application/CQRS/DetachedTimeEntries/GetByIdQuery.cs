using Application.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Application.CQRS.DetachedTimeEntries;

public class GetByIdQuery : IRequest<DetachedTimeEntryDTO>
{
    public required string Id { get; init; }
}

public class GetByIdQueryValidator : AbstractValidator<GetByIdQuery>
{
    public GetByIdQueryValidator()
    {
        RuleFor(query => query.Id)
            .NotNull()
            .WithMessage("Id cannot be null");
    }
}

public class GetByIdQueryHandler(IUnitOfWork uow, IMapper mapper) : IRequestHandler<GetByIdQuery, DetachedTimeEntryDTO>
{
    public async Task<DetachedTimeEntryDTO> Handle(GetByIdQuery request, CancellationToken cancellationToken)
    {
        return mapper.Map<DetachedTimeEntryDTO>(await uow.TimeEntryRepository.GetById(request.Id));
    }
}