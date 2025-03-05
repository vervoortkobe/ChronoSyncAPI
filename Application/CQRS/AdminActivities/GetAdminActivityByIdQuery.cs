using Application.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Application.CQRS.AdminActivities;

public class GetAdminActivityByIdQuery : IRequest<GetAdminActivityDTO>
{
    public required string Id { get; init; }
}

public class GetAdminActivityByIdQueryValidator : AbstractValidator<GetAdminActivityByIdQuery>
{
    public GetAdminActivityByIdQueryValidator()
    {
        RuleFor(query => query.Id)
            .NotNull()
            .WithMessage("Id cannot be null");
    }
}

public class GetAdminActivityByIdQueryHandler(IUnitOfWork uow, IMapper mapper) : IRequestHandler<GetAdminActivityByIdQuery, GetAdminActivityDTO>
{
    public async Task<GetAdminActivityDTO> Handle(GetAdminActivityByIdQuery request, CancellationToken cancellationToken)
    {
        return mapper.Map<GetAdminActivityDTO>(await uow.AdminActivityRepository.GetById(request.Id)!);
    }
}