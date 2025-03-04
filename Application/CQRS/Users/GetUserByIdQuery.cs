using Application.CQRS.Users.DTO;
using Application.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Application.CQRS.Users;

public class GetUserByIdQuery : IRequest<GetXylosUserDTO>
{
    public required string Id { get; init; }
}

public class GetUserByIdQueryValidator : AbstractValidator<GetUserByIdQuery>
{
    public GetUserByIdQueryValidator()
    {
        RuleFor(query => query.Id)
            .NotNull()
            .WithMessage("Id cannot be null");
    }
}

public class GetUserByIdDbQueryHandler(IUnitOfWork uow, IMapper mapper)
    : IRequestHandler<GetUserByIdQuery, GetXylosUserDTO>
{
    public async Task<GetXylosUserDTO> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        return mapper.Map<GetXylosUserDTO>(await uow.XylosUserRepository.GetById(request.Id)!);
    }
}