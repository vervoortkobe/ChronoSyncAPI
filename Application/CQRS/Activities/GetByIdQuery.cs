using Application.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Application.CQRS.Activities;

public class GetByIdQuery : IRequest<ActivityDTO>
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

public class GetByIdQueryHandler(IUnitOfWork uow, IMapper mapper) : IRequestHandler<GetByIdQuery, ActivityDTO>
{
    public async Task<ActivityDTO> Handle(GetByIdQuery request, CancellationToken cancellationToken)
    {
        return mapper.Map<ActivityDTO>(await uow.ActivityRepository.GetById(request.Id)!);
    }
}