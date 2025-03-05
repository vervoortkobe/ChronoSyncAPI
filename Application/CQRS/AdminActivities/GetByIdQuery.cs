using Application.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Application.CQRS.AdminActivities;

public class GetByIdQuery : IRequest<AdminActivityDTO>
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

public class GetByIdQueryHandler(IUnitOfWork uow, IMapper mapper) : IRequestHandler<GetByIdQuery, AdminActivityDTO>
{
    public async Task<AdminActivityDTO> Handle(GetByIdQuery request, CancellationToken cancellationToken)
    {
        return mapper.Map<AdminActivityDTO>(await uow.ActivityRepository.GetById(request.Id));
    }
}