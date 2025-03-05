using Application.Interfaces;
using FluentValidation;
using MediatR;

namespace Application.CQRS.DetachedTimeEntries;

public class DeleteCommand : IRequest<Boolean>
{
    public required string Id { get; init; }
}

public class DeleteCommandValidator : AbstractValidator<AddCommand>
{
    public DeleteCommandValidator(IUnitOfWork uow)
    {
        RuleFor(x => x.DetachedTimeEntry.Id)
            .NotNull()
            .WithMessage("Id cannot be empty");
    }
}

public class DeleteCommandHandler(IUnitOfWork uow) : IRequestHandler<DeleteCommand, Boolean>
{
    public async Task<Boolean> Handle(DeleteCommand request, CancellationToken cancellationToken)
    {
        await uow.DetachedTimeEntryRepository.Delete(request.Id!);
        return true;
    }
}