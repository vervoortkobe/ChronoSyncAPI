using Application.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Application.CQRS.TimeEntries;

public class GetByIdQuery : IRequest<TimeEntryDTO>
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

public class GetByIdQueryHandler(IUnitOfWork uow, IMapper mapper) : IRequestHandler<GetByIdQuery, TimeEntryDTO>
{
    public async Task<TimeEntryDTO> Handle(GetByIdQuery request, CancellationToken cancellationToken)
    {
        return mapper.Map<TimeEntryDTO>(await uow.TimeEntryRepository.GetById(request.Id));
    }
}