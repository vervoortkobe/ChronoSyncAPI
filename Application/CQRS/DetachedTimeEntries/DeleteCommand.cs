using Application.Interfaces;
using FluentValidation;
using MediatR;

namespace Application.CQRS.DetachedTimeEntries;

public class DeleteCommand : IRequest<bool>
{
    public required string ActivityId { get; init; }
    public required string TimeEntryId { get; init; }
}

public class DeleteCommandValidator : AbstractValidator<DeleteCommand>
{
    public DeleteCommandValidator(IUnitOfWork uow)
    {
        RuleFor(x => x.ActivityId)
            .NotNull()
            .WithMessage("ActivityId cannot be empty");

        RuleFor(x => x.TimeEntryId)
            .NotNull()
            .WithMessage("TimeEntryId cannot be empty");

        RuleFor(x => x.TimeEntryId)
            .MustAsync(async (command, id, cancellation) =>
            {
                var timeEntry = await uow.TimeEntryRepository.GetById(id);
                return timeEntry != null && timeEntry.Activity.Id == command.ActivityId;
            })
            .WithMessage("The specified TimeEntry does not exist or does not match the ActivityId");
    }
}

public class DeleteCommandHandler(IUnitOfWork uow) : IRequestHandler<DeleteCommand, bool>
{
    public async Task<bool> Handle(DeleteCommand request, CancellationToken cancellationToken)
    {
        await uow.TimeEntryRepository.Delete(request.TimeEntryId!);
        return true;
    }
}