using Application.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Application.CQRS.DetachedTimeEntries;

public class AddCommand : IRequest<AddDetachedTimeEntryDTO>
{
    public required string Id { get; init; }
}

public class AddCommandValidator : AbstractValidator<AddCommand>
{
    public AddCommandValidator()
    {
        RuleFor(query => query.Id)
            .NotNull()
            .WithMessage("Id cannot be null");
    }
}

public class AddCommandHandler(IUnitOfWork uow, IMapper mapper) : IRequestHandler<AddCommand, AddDetachedTimeEntryDTO>
{
    public async Task<AddDetachedTimeEntryDTO> Handle(AddCommand request, CancellationToken cancellationToken)
    {
        return mapper.Map<AddDetachedTimeEntryDTO>(await uow.DetachedTimeEntryRepository.GetById(request.Id)!);
    }
}