using Application.CQRS.Users.DTO;
using Application.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Application.CQRS.Users;

public class GetAllUsersQuery : IRequest<IEnumerable<GetXylosUserDTO>>
{
}

public class GetAllUsersQueryValidator : AbstractValidator<GetAllUsersQuery>
{
    public GetAllUsersQueryValidator()
    {
    }
}

public class GetAllUsersQueryHandler(IUnitOfWork uow, IMapper mapper) : IRequestHandler<GetAllUsersQuery, IEnumerable<GetXylosUserDTO>>
{
    public async Task<IEnumerable<GetXylosUserDTO>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        return mapper.Map<IEnumerable<GetXylosUserDTO>>(await uow.XylosUserRepository.GetAll()!);
    }
}