using Application.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Application.CQRS.Users;

public class GetAllQuery : IRequest<IEnumerable<XylosUserDTO>>
{
}

public class GetAllQueryValidator : AbstractValidator<GetAllQuery>
{
    public GetAllQueryValidator()
    {
    }
}

public class GetAllQueryHandler(IUnitOfWork uow, IMapper mapper) : IRequestHandler<GetAllQuery, IEnumerable<XylosUserDTO>>
{
    public async Task<IEnumerable<XylosUserDTO>> Handle(GetAllQuery request, CancellationToken cancellationToken)
    {
        return mapper.Map<IEnumerable<XylosUserDTO>>(await uow.XylosUserRepository.GetAll()!);
    }
}