using Application.Interfaces;
using AutoMapper;
using Domain.Model.Activities;
using FluentValidation;
using MediatR;

namespace Application.CQRS.Users;

public class GetAllActivitiesQuery : IRequest<IEnumerable<GetActivityDTO>>
{
}

public class GetAllActivitiesQueryValidator : AbstractValidator<GetAllActivitiesQuery>
{
    public GetAllActivitiesQueryValidator()
    {
    }
}

public class GetAllActivitiesQueryHandler(IUnitOfWork uow, IMapper mapper) : IRequestHandler<GetAllActivitiesQuery, IEnumerable<GetActivityDTO>>
{
    public async Task<IEnumerable<GetActivityDTO>> Handle(GetAllActivitiesQuery request, CancellationToken cancellationToken)
    {
        return mapper.Map<IEnumerable<GetActivityDTO>>(await uow.ActivityRepository.GetAll()!);
    }
}