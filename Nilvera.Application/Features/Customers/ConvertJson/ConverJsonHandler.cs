using MediatR;
using Newtonsoft.Json;
using Nilvera.Application.Repository;
using Nilvera.Domain.Entities;

namespace Nilvera.Application.Features.Customers.ConvertJson
{
    public class ConverJsonHandler : IRequestHandler<ConvertJsonQuery, Customer>
    {
        ICustomerRepository _repository;
        public ConverJsonHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }
        public async Task<Customer> Handle(ConvertJsonQuery request, CancellationToken cancellationToken)
        {
            var list = await _repository.GetJsonValueAsync();
            if (list.Count > 0)
            {
                try
                {
                    return JsonConvert.DeserializeObject<Customer>(list.FirstOrDefault().JsonString);
                }
                catch (JsonException ex)
                {
                    throw new Exception("Error deserializing JSON data: " + ex.Message);
                }
            }
            throw new Exception("Error deserializing JSON data is null");

        }
    }

    public class ConvertJsonQuery : IRequest<Customer>
    {
    }
}
