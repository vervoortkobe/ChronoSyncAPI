using Application.Interfaces;
using FluentValidation;
using MediatR;

namespace Application.CQRS.TimeEntries;

public class DeleteCommand : IRequest<Boolean>
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
            .WithMessage("The specified time entry does not exist or does not match the activity ID");
    }
}

public class DeleteCommandHandler(IUnitOfWork uow) : IRequestHandler<DeleteCommand, Boolean>
{
    public async Task<Boolean> Handle(DeleteCommand request, CancellationToken cancellationToken)
    {
        await uow.TimeEntryRepository.Delete(request.TimeEntryId!);
        return true;
    }
}