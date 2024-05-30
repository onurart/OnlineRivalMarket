using OnlineRivalMarket.Application;
using OnlineRivalMarket.Application.Behavior;
using FluentValidation;
using MediatR;
using System.Net.Sockets;

namespace OnlineRivalMarket.WebApi.Configurations
{
    public class ApplicationServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cfg => { cfg.RegisterServicesFromAssemblies(typeof(AssemblyReference).Assembly); });
            services.AddTransient(typeof(IPipelineBehavior<,>), (typeof(ValidationBehavior<,>)));
            services.AddValidatorsFromAssembly(typeof(AssemblyReference).Assembly);

        }
    }
}