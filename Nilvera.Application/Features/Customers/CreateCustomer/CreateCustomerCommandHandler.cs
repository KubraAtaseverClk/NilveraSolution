using MediatR;
using Nilvera.Application.Repository;

namespace Nilvera.Application.Features.Customers.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, int>
    {
        ICustomerRepository _repository;
        public CreateCustomerCommandHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }
        public async Task<int> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
           return await _repository.InsertAsync(request);
        }
    }

    public class CreateCustomerCommand(string Name, string Surname, string Address) : IRequest<int>
    {
        public string? Name { get; set; } = Name;
        public string? Surname { get; set; } = Surname;
        public string? Address { get; set; } = Address;
    }
}
