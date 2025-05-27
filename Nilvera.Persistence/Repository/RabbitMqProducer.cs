using System.Text;
using Newtonsoft.Json;
using Nilvera.Application.Repository;
using Nilvera.Domain.Entities;
using RabbitMQ.Client;

namespace Nilvera.Persistence.Repository
{
    public class RabbitMqProducer : IMessageProducer
    {
        private readonly IRabbitMqConnection _connection;
        public RabbitMqProducer(IRabbitMqConnection rabbitMqConnection)
        {
            _connection = rabbitMqConnection;
        }

        public async void SendMessage(List<Customer> message)
        {
            var channel = await _connection.Connection.CreateChannelAsync();
            var body = JsonConvert.SerializeObject(message);

            await channel.QueueDeclareAsync("customers", exclusive: false);

            await channel.BasicPublishAsync(exchange: "",
                routingKey: "customers",
                body: Encoding.UTF8.GetBytes(body));

        }
    }
}
