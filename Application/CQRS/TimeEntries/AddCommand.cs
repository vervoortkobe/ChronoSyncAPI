using Application.Interfaces;
using AutoMapper;
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
        private IUnitOfWork uow;

        public AddCommandValidator(IUnitOfWork uow)
        {
            this.uow = uow;

            RuleFor(s => s.Person.FirstName)
                .NotNull()
                .WithMessage("Firstname cannot be empty");

            RuleFor(s => s.Person.FirstName)
                .MaximumLength(15)
                .WithMessage("Firstname is too long");

            RuleFor(s => s.Person.EmployerId)
                .MustAsync(async (id, cancellation) =>
                {
                    var employer = await uow.StoresRepository.GetById(id);
                    return (employer != null);
                })
                .WithMessage("The specified employer does not exist");
        }
    }
    public class AddCommandHandler : IRequestHandler<AddCommand, TimeEntryDTO>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public AddCommandHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }
        public async Task<TimeEntryDTO> Handle(AddCommand request, CancellationToken cancellationToken)
        {
            //var employer = await uow.StoresRepository.GetById(request.Person.EmployerId);
            //if (employer == null)
            //    throw new RelationNotFoundException("The specified employer does not exist");

            await uow.PeopleRepository.Create(mapper.Map<Person>(request.Person));
            await uow.Commit();
            return request.Person;
        }
    }
}