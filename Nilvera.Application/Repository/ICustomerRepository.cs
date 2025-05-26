using Nilvera.Application.Features.Customers.CreateCustomer;
using Nilvera.Application.Features.Customers.UpdateCustomer;
using Nilvera.Domain.Entities;

namespace Nilvera.Application.Repository
{
    public interface ICustomerRepository
    {
        public Task<Customer?> GetByIdAsync(int id);
        public Task<int> InsertAsync(CreateCustomerCommand data);
        public Task<int> UpdateAsync(UpdateCustomerCommand data);
        public Task<int> DeleteAsync(DeleteCustomerCommand data);
        public Task<List<Customer>> ListAsync();
        public Task<List<JsonValue>> GetJsonValueAsync();
    }
}
