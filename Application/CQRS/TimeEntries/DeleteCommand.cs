using Application.Interfaces;
using Domain.Model.Activities;
using Domain.Model.TimeEntries;
using FluentValidation;
using MediatR;

namespace Application.CQRS.TimeEntries;

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
        Activity activity = await uow.ActivityRepository.GetById(request.ActivityId);
        TimeEntry timeEntry = await uow.TimeEntryRepository.GetById(request.TimeEntryId);

        if (timeEntry!.EndTime != null && timeEntry.StartTime != null && timeEntry.Break != null)
            activity!.CalculatedMinutesSpent -= (int?)(timeEntry.EndTime - timeEntry.StartTime).Value.TotalMinutes;
        else
            activity!.CalculatedMinutesSpent -= timeEntry.Duration!;

        await uow.ActivityRepository.Update(request.ActivityId, activity);

        await uow.TimeEntryRepository.Delete(request.TimeEntryId!);
        return true;
    }
}