using Application.Interfaces;
using AutoMapper;
using Domain.Model.TimeEntries;
using FluentValidation;
using MediatR;

namespace Application.CQRS.TimeEntries
{
    public class UpdateCommand : IRequest<TimeEntryDTO>
    {
        public required TimeEntryDTO TimeEntry { get; set; }
    }

    public class UpdateCommandValidator : AbstractValidator<AddCommand>
    {
        public UpdateCommandValidator(IUnitOfWork uow)
        {
            RuleFor(x => x.TimeEntry.Id)
                .NotNull()
                .WithMessage("Id cannot be empty");

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

    public class UpdateCommandHandler(IUnitOfWork uow, IMapper mapper) : IRequestHandler<UpdateCommand, TimeEntryDTO>
    {
        public async Task<TimeEntryDTO> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            await uow.TimeEntryRepository.Update(request.TimeEntry.Id!, mapper.Map<TimeEntry>(request.TimeEntry));
            return request.TimeEntry;
        }
    }
}