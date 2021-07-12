using System;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RabbitMQ.Client;

namespace DevMeetings.Services.Users.Infrastructure.MessageBus
{
    public class RabbitMQClient : IMessageBusClient
    {
        private readonly IConnection _connection;
        public RabbitMQClient()
        {
            var connectionFactory = new ConnectionFactory {
                HostName = "localhost"
            };

            _connection = connectionFactory.CreateConnection("users-service-producer"); 
        }
        
        public void Publish(object message, string routingKey, string exchange)
        {
            Console.WriteLine($"routing Key: {routingKey}, Exchange: {exchange}");
            
            var channel = _connection.CreateModel();

            var settings = new JsonSerializerSettings {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            var payload = JsonConvert.SerializeObject(message, settings);
            Console.WriteLine(payload);

            var body = Encoding.UTF8.GetBytes(payload);
            
            channel.ExchangeDeclare(exchange, "topic", true);

            // channel.QueueDeclare(queue, false, false, false, null);
            // channel.QueueBind(queue, exchange, queue, null);
            Console.WriteLine($"{exchange}->{routingKey}");

            channel.BasicPublish(exchange, routingKey, null, body);
        }
    }
}