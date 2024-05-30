using Microsoft.EntityFrameworkCore;
using OnlineRivalMarket.Application.Services.LogService;
using OnlineRivalMarket.Domain.AppEntities.Identity;
using OnlineRivalMarket.Persistance;
using OnlineRivalMarket.Persistance.Context;

namespace OnlineRivalMarket.WebApi.Configurations
{
    public class PersistanceServiceInstaller : IServiceInstaller
    {
        private const string SectionName = "SqlServer";
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString(SectionName);
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
            services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<AppDbContext>();
            services.AddAutoMapper(typeof(AssemblyReference).Assembly);
            services.AddScoped(typeof(ILogDataFactory<>), typeof(LogDataFactory<>));

        }
    }

}
