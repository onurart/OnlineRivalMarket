using OnlineRivalMarket.Application.Abstractions;
using OnlineRivalMarket.Application.Services;
using OnlineRivalMarket.Infrasturcture.Services;
using OnlineRivalMarket.Infrasturcture.Authentication;

namespace OnlineRivalMarket.WebApi.Configurations
{
    public class InfrustructureDIServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IJwtProvider, JwtProvider>();
            services.AddScoped<IApiService, ApiService>();
            services.AddScoped<IRabbitMQService, RabbitMQService>();
        }
    }
}
