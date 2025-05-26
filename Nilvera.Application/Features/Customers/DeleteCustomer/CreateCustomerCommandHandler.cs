using MediatR;
using Nilvera.Application.Repository;

namespace Nilvera.Application.Features.Customers.CreateCustomer
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, int>
    {
        ICustomerRepository _repository;
        public DeleteCustomerCommandHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }
        public async Task<int> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
           return await _repository.DeleteAsync(request);
        }
    }

    public class DeleteCustomerCommand(int Id) : IRequest<int>
    {
        public int Id { get; set; } = Id;
    }
}
