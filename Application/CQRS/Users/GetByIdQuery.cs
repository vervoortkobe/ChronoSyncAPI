using Application.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Application.CQRS.Users;

public class GetByIdQuery : IRequest<XylosUserDTO>
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

public class GetByIdDbQueryHandler(IUnitOfWork uow, IMapper mapper) : IRequestHandler<GetByIdQuery, XylosUserDTO>
{
    public async Task<XylosUserDTO> Handle(GetByIdQuery request, CancellationToken cancellationToken)
    {
        return mapper.Map<XylosUserDTO>(await uow.XylosUserRepository.GetById(request.Id));
    }
}