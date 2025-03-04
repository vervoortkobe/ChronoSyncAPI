using Application.CQRS.Users.DTO;
using Application.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Application.CQRS.Users;

public class GetAllUsersQuery : IRequest<GetXylosUserDTO>
{
}

public class GetAllUsersQueryValidator : AbstractValidator<GetAllUsersQuery>
{
    public GetAllUsersQueryValidator()
    {
    }
}

public class GetAllUsersQueryHandler(IUnitOfWork uow, IMapper mapper) : IRequestHandler<GetAllUsersQuery, GetXylosUserDTO>
{
    public async Task<GetXylosUserDTO> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        return mapper.Map<GetXylosUserDTO>(await uow.XylosUserRepository.GetAll()!);
    }
}