using Application.Interfaces;
using AutoMapper;
using Domain.Model.Activities;
using FluentValidation;
using MediatR;

namespace Application.CQRS.Users;

public class GetActivityByIdQuery : IRequest<GetActivityDTO>
{
    public required string Id { get; init; }
}

public class GetActivityByIdQueryValidator : AbstractValidator<GetActivityByIdQuery>
{
    public GetActivityByIdQueryValidator()
    {
        RuleFor(query => query.Id)
            .NotNull()
            .WithMessage("Id cannot be null");
    }
}

public class GetActivityByIdQueryHandler(IUnitOfWork uow, IMapper mapper) : IRequestHandler<GetActivityByIdQuery, GetActivityDTO>
{
    public async Task<GetActivityDTO> Handle(GetActivityByIdQuery request, CancellationToken cancellationToken)
    {
        return mapper.Map<GetActivityDTO>(await uow.ActivityRepository.GetById(request.Id)!);
    }
}