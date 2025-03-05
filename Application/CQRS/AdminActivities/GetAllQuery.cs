using Application.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Application.CQRS.AdminActivities;

public class GetAllQuery : IRequest<IEnumerable<AdminActivityDTO>>
{
}

public class GetAllQueryValidator : AbstractValidator<GetAllQuery>
{
    public GetAllQueryValidator()
    {
    }
}

public class GetAllQueryHandler(IUnitOfWork uow, IMapper mapper) : IRequestHandler<GetAllQuery, IEnumerable<AdminActivityDTO>>
{
    public async Task<IEnumerable<AdminActivityDTO>> Handle(GetAllQuery request, CancellationToken cancellationToken)
    {
        return mapper.Map<IEnumerable<AdminActivityDTO>>(await uow.AdminActivityRepository.GetAll()!);
    }
}