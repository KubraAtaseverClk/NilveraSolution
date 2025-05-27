using RabbitMQ.Client;

namespace Nilvera.Application.Repository
{
    public interface IRabbitMqConnection
    {
        IConnection Connection { get; }
    }
}
