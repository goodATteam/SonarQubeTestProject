namespace CatalogServiceNetAdvanced.WebAPI.RabbitMQ
{
    public interface IRabitMQProducer
    {
        public void SendProductMessage<T>(T message);
    }
}