using System.Text;
using Newtonsoft.Json;
using Nilvera.Domain.Entities;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

var factory = new ConnectionFactory
{
    Uri= new Uri("amqp://guest:guest@localhost:5672")
};
var connection = await factory.CreateConnectionAsync();
using var channel = await connection.CreateChannelAsync();
await channel.QueueDeclareAsync("customers", exclusive: false);

var consumer = new AsyncEventingBasicConsumer(channel);
consumer.ReceivedAsync += async (s, e) =>
{
    byte[] body = e.Body.ToArray();
    var message = "";

    var customers = JsonConvert.DeserializeObject<List<Customer>>(Encoding.UTF8.GetString(body));
    using (var stringWriter = new StringWriter())
    {
        var serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<Customer>));
        serializer.Serialize(stringWriter, customers);
        message = stringWriter.ToString();
    }

    Console.WriteLine($"Received message: {message}");
};
await channel.BasicConsumeAsync(queue: "customers", autoAck: true, consumer: consumer);
Console.ReadKey();