using Application.Interfaces;
using AutoMapper;
using Domain.Model.TimeEntries;
using FluentValidation;
using MediatR;

namespace Application.CQRS.TimeEntries
{
    public class AddCommand : IRequest<TimeEntryDTO>
    {
        public required TimeEntryDTO TimeEntry { get; set; }
    }

    public class AddCommandValidator : AbstractValidator<AddCommand>
    {
        public AddCommandValidator(IUnitOfWork uow)
        {
            RuleFor(x => x.TimeEntry.Activity)
                .NotNull()
                .WithMessage("Activity cannot be empty");

            RuleFor(x => x.TimeEntry.Activity.Id)
                .MustAsync(async (id, cancellation) =>
                {
                    var activity = await uow.ActivityRepository.GetById(id);
                    return (activity != null);
                })
                .WithMessage("The specified activity does not exist");

            RuleFor(x => x.TimeEntry)
                .Must(x => (x.StartTime.HasValue && x.EndTime.HasValue) || x.Duration.HasValue)
                .WithMessage("TimeEntry must have StartTime and EndTime, or Duration");
        }
    }

    public class AddCommandHandler(IUnitOfWork uow, IMapper mapper) : IRequestHandler<AddCommand, TimeEntryDTO>
    {
        public async Task<TimeEntryDTO> Handle(AddCommand request, CancellationToken cancellationToken)
        {
            await uow.TimeEntryRepository.Create(mapper.Map<TimeEntry>(request.TimeEntry));
            return request.TimeEntry;
        }
    }
}