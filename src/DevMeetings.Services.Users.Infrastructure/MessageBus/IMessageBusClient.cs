namespace DevMeetings.Services.Users.Infrastructure.MessageBus
{
    public interface IMessageBusClient
    {
        void Publish(object message, string routingKey, string exchange);
    }
}