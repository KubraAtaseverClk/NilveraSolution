using MediatR;
using Nilvera.Application.Repository;

namespace Nilvera.Application.Features.Customers.ConvertXML
{
    public class ConvertXMLHandler : IRequestHandler<ConvertXMLQuery, bool>
    {
        private readonly IXmlRepository _repository;
        public ConvertXMLHandler(IXmlRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Handle(ConvertXMLQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetXMLAsync();
        }
    }

    public class ConvertXMLQuery : IRequest<bool>
    {

    }
}
