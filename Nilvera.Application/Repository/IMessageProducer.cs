using Nilvera.Domain.Entities;

namespace Nilvera.Application.Repository
{
    public interface IMessageProducer
    {
        void SendMessage(List<Customer> message);
    }
}
