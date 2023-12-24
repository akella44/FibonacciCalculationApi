namespace FibonacciCalculationApi.RabbitMq
{
    public interface IRabbitMqService
    {
        public void PutToQueue(string queueName, string message);
    }
}
