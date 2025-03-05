using Application.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Application.CQRS.AdminActivities;

public class GetAllAdminActivitiesQuery : IRequest<IEnumerable<GetAdminActivityDTO>>
{
}

public class GetAllAdminActivitiesQueryValidator : AbstractValidator<GetAllAdminActivitiesQuery>
{
    public GetAllAdminActivitiesQueryValidator()
    {
    }
}

public class GetAllAdminActivitiesQueryHandler(IUnitOfWork uow, IMapper mapper) : IRequestHandler<GetAllAdminActivitiesQuery, IEnumerable<GetAdminActivityDTO>>
{
    public async Task<IEnumerable<GetAdminActivityDTO>> Handle(GetAllAdminActivitiesQuery request, CancellationToken cancellationToken)
    {
        return mapper.Map<IEnumerable<GetAdminActivityDTO>>(await uow.AdminActivityRepository.GetAll()!);
    }
}