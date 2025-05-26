using MediatR;
using Nilvera.Application.Repository;

namespace Nilvera.Application.Features.Customers.UpdateCustomer
{
    public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand, int>
    {
        ICustomerRepository _repository;
        public UpdateCustomerHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }
        public async Task<int> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            return await _repository.UpdateAsync(request);
        }
    }

    public class UpdateCustomerCommand(int Id, string Name, string Surname, string Address) : IRequest<int>
    {
        public int Id { get; set; } = Id;
        public string? Name { get; set; } = Name;
        public string? Surname { get; set; } = Surname;
        public string? Address { get; set; } = Address;
    }
}
