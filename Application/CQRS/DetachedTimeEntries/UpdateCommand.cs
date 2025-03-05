using Application.Interfaces;
using AutoMapper;
using Domain.Model.TimeEntries;
using FluentValidation;
using MediatR;

namespace Application.CQRS.DetachedTimeEntries;

public class UpdateCommand : IRequest<DetachedTimeEntryDTO>
{
    public required DetachedTimeEntryDTO DetachedTimeEntry { get; init; }
}

public class UpdateCommandValidator : AbstractValidator<AddCommand>
{
    public UpdateCommandValidator(IUnitOfWork uow)
    {
        RuleFor(x => x.DetachedTimeEntry.Id)
            .NotNull()
            .WithMessage("Id cannot be empty");

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
            .NotEmpty()
            .WithMessage("Description cannot be empty");
    }
}

public class UpdateCommandHandler(IUnitOfWork uow, IMapper mapper) : IRequestHandler<UpdateCommand, DetachedTimeEntryDTO>
{
    public async Task<DetachedTimeEntryDTO> Handle(UpdateCommand request, CancellationToken cancellationToken)
    {
        await uow.DetachedTimeEntryRepository.Update(request.DetachedTimeEntry.Id!, mapper.Map<DetachedTimeEntry>(request.DetachedTimeEntry));
        return request.DetachedTimeEntry;
    }
}