namespace OnlineRivalMarket.Application.Services
{
    public interface IRabbitMQService
    {
        void SendQueue(CategoryDto categoryDto);
    }
}
