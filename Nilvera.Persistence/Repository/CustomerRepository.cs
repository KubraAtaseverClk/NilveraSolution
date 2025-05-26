using Azure.Core;
using Nilvera.Application.Features.Customers.CreateCustomer;
using Nilvera.Application.Features.Customers.GetCustomer;
using Nilvera.Application.Features.Customers.UpdateCustomer;
using Nilvera.Application.Repository;
using Nilvera.Domain.Entities;

namespace Nilvera.Application.Service
{
    public class CustomerRepository : ICustomerRepository
    {
        public async Task<int> DeleteAsync(DeleteCustomerCommand data)
        {
            return await Task.Run(() => DBUtils.DbBase!.Query<int>("DELETE_CUSTOMER", new { Id = data.Id }));
        }

        public async Task<Customer?> GetByIdAsync(int id)
        {
            return await Task.Run(() => DBUtils.DbBase!.Query<Customer>("GET_CUSTOMER", new { Id = id }));
        }

        public async Task<List<JsonValue>> GetJsonValueAsync()
        {
            return await Task.Run(() => DBUtils.DbBase!.QueryList<JsonValue>("GET_JSONVALUE", null));
        }

        public async Task<int> InsertAsync(CreateCustomerCommand request)
        {
            var customer = new
            {
                name = request.Name,
                surname = request.Surname,
                address = request.Address
            };

            var id = await Task.Run(() => DBUtils.DbBase!.Query<int>("CREATE_CUSTOMER", customer));
            return id;
        }

        public async Task<List<Customer>> ListAsync()
        {
            return await Task.Run(() => DBUtils.DbBase!.QueryList<Customer>("GETLIST_CUSTOMER", null));
        }

        public async Task<int> UpdateAsync(UpdateCustomerCommand request)
        {
            var customer = new
            {
                Id = request.Id,
                Name = request.Name,
                Surname = request.Surname,
                address = request.Address
            };

            var id = await Task.Run(() => DBUtils.DbBase!.Query<int>("UPDATE_CUSTOMER", customer));
            return id;
        }
    }
}
