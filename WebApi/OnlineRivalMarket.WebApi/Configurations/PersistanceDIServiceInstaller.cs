using OnlineRivalMarket.Application.Services.CompanyServices;
using OnlineRivalMarket.Application.Services.AppServices;
using OnlineRivalMarket.Application.Services.CompanyServices;
using OnlineRivalMarket.Domain.Repositories.AppDbContext.CompanyRepositories;
using OnlineRivalMarket.Domain.Repositories.AppDbContext.MainRoleAndUserRelationshipRepositories;
using OnlineRivalMarket.Domain.Repositories.AppDbContext.MainRoleReporistories;
using OnlineRivalMarket.Domain.Repositories.AppDbContext.UserAndCompanyRelationshipRepositories;
using OnlineRivalMarket.Domain.Repositories.AppDbContext.UserRoleRepositories;
using OnlineRivalMarket.Domain.Repositories.CompanyDbContext.BrandRepositories;
using OnlineRivalMarket.Domain.Repositories.CompanyDbContext.CampaignRepository;
using OnlineRivalMarket.Domain.Repositories.CompanyDbContext.CategoryRepository;
using OnlineRivalMarket.Domain.Repositories.CompanyDbContext.LogRepositories;
using OnlineRivalMarket.Domain.Repositories.CompanyDbContext.ProductRepositories;
using OnlineRivalMarket.Domain.UnitOfWorks;
using OnlineRivalMarket.Domain;
using OnlineRivalMarket.Persistance.UnitOfWorks;
using OnlineRivalMarket.Persistance;
using OnlineRivalMarket.Persistance.Services.CompanyServices;
using OnlineRivalMarket.Persistance.Services.AppServices;
using OnlineRivalMarket.Persistance.Repositories.CompanyDbContext.LogRepositories;
using OnlineRivalMarket.Persistance.Repositories.CompanyDbContext.ProductRepositories;
using OnlineRivalMarket.Persistance.Repositories.CompanyDbContext.CategoryRepository;
using OnlineRivalMarket.Persistance.Repositories.CompanyDbContext.BrandRepositories;
using OnlineRivalMarket.Persistance.Repositories.AppDbContext.CompanyRepositories;
using OnlineRivalMarket.Persistance.Repositories.AppDbContext.MainRoleRepositories;
using OnlineRivalMarket.Persistance.Repositories.AppDbContext.MainRoleAndUserRelationshipRepositories;
using OnlineRivalMarket.Persistance.Repositories.AppDbContext.UserAndCompanyRelationshipCommandRepository;
using OnlineRivalMarket.Persistance.Repositories.AppDbContext.UserRoleRepositories;
using OnlineRivalMarket.Persistance.Repositories.CompanyDbContext.CampaignRepository;
using OnlineRivalMarket.Domain.Repositories.CompanyDbContext.CompetitorRepository;
using OnlineRivalMarket.Persistance.Repositories.CompanyDbContext.CompetitorsRepository;
using OnlineRivalMarket.Domain.Repositories.CompanyDbContext.IntelligenceRecordRepository;
using OnlineRivalMarket.Persistance.Repositories.CompanyDbContext.IntelligenceRecordRepository;
using OnlineRivalMarket.Domain.CompanyEntities;
using OnlineRivalMarket.Domain.Repositories.CompanyDbContext.FieldInformationRepository;
using OnlineRivalMarket.Persistance.Repositories.CompanyDbContext.FieldInformationRepository;
using OnlineRivalMarket.Domain.Repositories.CompanyDbContext.VehicleGroupRepository;
using OnlineRivalMarket.Persistance.Repositories.CompanyDbContext;
using OnlineRivalMarket.Persistance.Repositories.CompanyDbContext.SalesRepository;
using OnlineRivalMarket.Domain.Repositories.CompanyDbContext.VehicleTypeRepository;
using OnlineRivalMarket.Persistance.Repositories.CompanyDbContext.VehicleTypeRepository;

namespace OnlineRivalMarket.WebApi.Configurations
{
    public class PersistanceDIServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            #region Context UnitOfWork
            services.AddScoped<ICompanyDbUnitOfWork, CompanyDbUnitOfWork>();
            services.AddScoped<IAppUnitOfWork, AppUnitOfWork>();
            services.AddScoped<IContextService, ContextService>();
            #endregion

            #region Services
            #region CompanyDbContext
            services.AddScoped<ILogService, LogService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICompetitorService, CompetitorService>();
            services.AddScoped<IIntelligenceRecordService, IntelligenceRecordService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<ICampaignService, CampaignsService>();
            services.AddScoped<IFieldInformationService, FieldInformationService>();
            services.AddScoped<IVehicleGroupService, VehicleGroupService>();
            services.AddScoped<IVehicleTypeService, VehicleTypeService>();

            #endregion

            #region AppDbContext
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IMainRoleService, MainRoleService>();
            services.AddScoped<IMainRoleAndUserRelationshipService, MainRoleAndUserRelationshipService>();
            services.AddScoped<IUserAndCompanyRelationshipService, UserAndCompanyRelationshipService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserRoleService, UserRoleService>();
            #endregion
            #endregion

            #region Repositories
            #region CompanyDbContext
            services.AddScoped<ILogCommandRepository, LogCommandRepository>();
            services.AddScoped<ILogQueryRepository, LogQueryRepository>();
            services.AddScoped<IProductCommandRepository, ProductCommandRepository>();
            services.AddScoped<IProductQueryRepository, ProductQueryRepository>();
            services.AddScoped<ICompetitorCommandRepository, CompetitorsCommandRepository>();
            services.AddScoped<ICompetitorQueryRepository, CompetitorsQueryRepository>();
            services.AddScoped<IIntelligenceRecordCommandRepository, IntelligenceRecordCommandRepository>();
            services.AddScoped<IIntelligenceRecordQueryRepository, IntelligenceRecordQueryRepository>();
            services.AddScoped<ICategoryCommandRepository, CategoryCommandRepository>();
            services.AddScoped<ICategoryQueryRepository, CategoryQueryRepository>();

            services.AddScoped<IBrandCommandRepository, BrandCommandRepository>();
            services.AddScoped<IBrandQueryRepository, BrandQueryRepository>();

            services.AddScoped<ICampaignCommandRepository, CampaignCommandRepository>();
            services.AddScoped<ICampaignQueryRepository, CampaignQueryRepository>();
            
            services.AddScoped<IFieldInformationCommandRepository, FieldInformationCommandRepository>();
            services.AddScoped<IFieldInformationQueryRepository, FieldInformationQueryRepository>();
            services.AddScoped<IVehicleGroupCommandRepository, VehicleGroupCommandRepository>();
            services.AddScoped<IVehicleGroupQueryRepository, VehicleGroupQueryRepository>();

            services.AddScoped<IVehicleTypeCommandRepository, VehicleTypeCommandRepository>();
            services.AddScoped<IVehicleTypeQuertRepository, VehicleTypeQueryRepository>();



            services.AddHttpClient();

            #endregion


            #region AppDbContext
            services.AddScoped<ICompanyCommandRepository, CompanyCommandRepository>();
            services.AddScoped<ICompanyQueryRepository, CompanyQueryRepository>();
            services.AddScoped<IMainRoleCommandRepository, MainRoleCommandRepository>();
            services.AddScoped<IMainRoleQueryRepository, MainRoleQueryRepository>();
            services.AddScoped<IMainRoleAndUserRelationshipCommandRepository, MainRoleAndUserRelationshipCommandRepository>();
            services.AddScoped<IMainRoleAndUserRelationshipQueryRepository, MainRoleAndUserRelationshipQueryRepository>();
            services.AddScoped<IUserAndCompanyRelationshipCommandRepository, UserAndCompanyRelationshipCommandRepository>();
            services.AddScoped<IUserAndCompanyRelationshipQueryRepository, UserAndCompanyRelationshipQueryRepository>();
            services.AddScoped<IUserRoleCommandRepository, UserRoleCommandRepository>();
            services.AddScoped<IUserRoleQueryRepository, UserRoleQueryRepository>();
            #endregion
            #endregion
        }
    }
}
