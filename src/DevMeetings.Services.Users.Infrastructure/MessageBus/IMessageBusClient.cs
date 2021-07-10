namespace DevMeetings.Services.Users.Infrastructure.MessageBus
{
    public interface IMessageBusClient
    {
        void Publish(object message, string queue, string exchange);
    }
}