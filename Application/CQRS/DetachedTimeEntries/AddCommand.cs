using Application.Interfaces;
using AutoMapper;
using Domain.Model.TimeEntries;
using FluentValidation;
using MediatR;

namespace Application.CQRS.DetachedTimeEntries
{
    public class AddCommand : IRequest<DetachedTimeEntryDTO>
    {
        public required DetachedTimeEntryDTO DetachedTimeEntry { get; set; }
    }

    public class AddCommandValidator : AbstractValidator<AddCommand>
    {
        public AddCommandValidator(IUnitOfWork uow)
        {
            RuleFor(x => x.DetachedTimeEntry.Category)
                .NotNull()
                .WithMessage("Category cannot be empty");

            RuleFor(x => x.DetachedTimeEntry.Date)
                .NotNull()
                .WithMessage("Date cannot be empty");

            RuleFor(x => x.DetachedTimeEntry)
                .Must(x => (x.StartTime.HasValue && x.EndTime.HasValue) || x.Duration.HasValue)
                .WithMessage("TimeEntry must have StartTime and EndTime, or Duration");

            RuleFor(x => x.DetachedTimeEntry.Description)
                .NotNull()
                .WithMessage("Description cannot be empty");
        }
    }

    public class AddCommandHandler(IUnitOfWork uow, IMapper mapper) : IRequestHandler<AddCommand, DetachedTimeEntryDTO>
    {
        public async Task<DetachedTimeEntryDTO> Handle(AddCommand request, CancellationToken cancellationToken)
        {
            await uow.DetachedTimeEntryRepository.Create(mapper.Map<DetachedTimeEntry>(request.DetachedTimeEntry));
            return request.DetachedTimeEntry;
        }
    }
}