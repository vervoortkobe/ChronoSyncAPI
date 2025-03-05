using Application.CQRS.TimeEntries.DTO;
using Application.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Application.CQRS.Users;

public class CreateDetachedTimeEntryCommand : IRequest<CreateDetachedTimeEntryDTO>
{
    public required string Id { get; init; }
}

public class CreateDetachedTimeEntryCommandValidator : AbstractValidator<CreateDetachedTimeEntryCommand>
{
    public CreateDetachedTimeEntryCommandValidator()
    {
        RuleFor(query => query.Id)
            .NotNull()
            .WithMessage("Id cannot be null");
    }
}

public class CreateDetachedTimeEntryCommandHandler(IUnitOfWork uow, IMapper mapper) : IRequestHandler<CreateDetachedTimeEntryCommand, CreateDetachedTimeEntryDTO>
{
    public async Task<CreateDetachedTimeEntryDTO> Handle(CreateDetachedTimeEntryCommand request, CancellationToken cancellationToken)
    {
        return mapper.Map<CreateDetachedTimeEntryDTO>(await uow.DetachedTimeEntryRepository.GetById(request.Id)!);
    }
}