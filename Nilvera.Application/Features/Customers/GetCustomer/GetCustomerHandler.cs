using MediatR;
using Nilvera.Application.Repository;
using Nilvera.Domain.Entities;

namespace Nilvera.Application.Features.Customers.GetCustomer
{
    public class GetCustomerQuery : IRequest<Customer>
    {
        public GetCustomerQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
    public class GetCustomerHandler : IRequestHandler<GetCustomerQuery, Customer>
    {
        private readonly ICustomerRepository _repository;
        public GetCustomerHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }
        public async Task<Customer?> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(request.Id);
        }
    }
}
