using Nilvera.Application.Repository;
using Nilvera.Domain.Entities;

namespace Nilvera.Persistence.Repository
{
    public class XmlRepository : IXmlRepository
    {
        private readonly IMessageProducer messageProducer;
        public XmlRepository(IMessageProducer messageProducer)
        {
            this.messageProducer = messageProducer;
        }

        public async Task<bool> GetXMLAsync()
        {
            var customers = DBUtils.DbBase!.QueryList<Customer>("GETLIST_CUSTOMER", null);
            messageProducer.SendMessage(customers);
            return true;
        }
    }
}
