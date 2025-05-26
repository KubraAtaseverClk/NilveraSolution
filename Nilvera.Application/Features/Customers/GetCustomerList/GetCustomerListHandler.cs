using MediatR;
using Nilvera.Application.Repository;
using Nilvera.Domain.Entities;

namespace Nilvera.Application.Features.Customers.GetCustomer
{
    public class GetCustomerListQuery : IRequest<List<Customer>>
    {
    }

    public class GetCustomerListHandler : IRequestHandler<GetCustomerListQuery, List<Customer>>
    {
        private readonly ICustomerRepository _repository;
        public GetCustomerListHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<Customer>?> Handle(GetCustomerListQuery request, CancellationToken cancellationToken)
        {
            return await _repository.ListAsync();
        }
    }
}
