using Newtonsoft.Json;
using RabbitMQ.Client;

namespace OnlineRivalMarket.Infrasturcture.Services
{
    public sealed class RabbitMQService : IRabbitMQService
    {
        public void SendQueue(CategoryDto categoryDto)
        {
            var factory = new ConnectionFactory();
            factory.Uri = new Uri("amqps://zibczzmo:G2_qaMHmkEOa1V8cMcH9NGcyNEwJK1-R@codfish.rmq.cloudamqp.com/zibczzmo");
            using var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            channel.QueueDeclare("Reports", true, false, false);
            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(categoryDto));
            channel.BasicPublish(String.Empty, "Reports", null, body);
        }
    }
}
