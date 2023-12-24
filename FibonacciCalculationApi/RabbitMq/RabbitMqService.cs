using FibonacciCalculationApi.RabbitMq;
using RabbitMQ.Client;
using System.Text;

namespace FibonacciCalculationApi.RabbitMq
{
    public class RabbitMqService : IRabbitMqService, IDisposable
    {
        private readonly IConfiguration _config;
        private IConnection _connection;
        public RabbitMqService(IConfiguration config)
        {
            _config = config;

            var connectionFactory = new ConnectionFactory()
            {
                HostName = _config["RabbitMQ:NodeIp"],
                Port = int.Parse(_config["RabbitMQ:Port"]),
                UserName = _config["RabbitMQ:UserName"],
                Password = _config["RabbitMQ:Password"]
            };

            _connection = connectionFactory.CreateConnection();
        }

        public void PutToQueue(string queueName, string message)
        {
            var body = Encoding.UTF8.GetBytes(message);

            using (var channel = _connection.CreateModel())
            {
                channel.BasicPublish(exchange: "",
                    routingKey: queueName,
                    basicProperties: null,
                    body: body);
            }
        }
        public void Dispose()
        {
            _connection.Dispose();
        }
    }
}
