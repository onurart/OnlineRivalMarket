using AutoMapper;
using OnlineRivalMarket.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using OnlineRivalMarket.Application.Features.AppFeatures.RoleFeatures.Commands.CreateRole;
using OnlineRivalMarket.Application.Features.CompanyFeatures.BrandFeaures.Commands.CreateBrand;
using OnlineRivalMarket.Application.Features.CompanyFeatures.CampaignFeaures.Commands.CreateCampaign;
using OnlineRivalMarket.Application.Features.CompanyFeatures.CategoryFeatures.Commands.CreateCategory;
using OnlineRivalMarket.Application.Features.CompanyFeatures.CompetitorsFeatures.Command.CreateCompetitors;
using OnlineRivalMarket.Application.Features.CompanyFeatures.FieldInformationFeatures.Commands;
using OnlineRivalMarket.Application.Features.CompanyFeatures.IntelligenceRecordFeatures.Commands.CreateIntelligenceRecord;
using OnlineRivalMarket.Application.Features.CompanyFeatures.ProductFeatures.Commands.CreateProduct;
using OnlineRivalMarket.Application.Features.CompanyFeatures.VehicleGroupFeaures.Commands.CreateVehicleGroup;
using OnlineRivalMarket.Application.Features.CompanyFeatures.VehicleTypeFeaures.Commands.CreateVehicleType;
using OnlineRivalMarket.Domain.AppEntities;
using OnlineRivalMarket.Domain.AppEntities.Identity;
using OnlineRivalMarket.Domain.CompanyEntities;
using OnlineRivalMarket.Domain.Dtos.HomeTopDto;

namespace OnlineRivalMarket.Persistance.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<CreateCompetitorsCommand, Competitor>();
            CreateMap<CreateCampaignCommand, Campaigns>();
            CreateMap<CreateCategoryCommand, Category>();
            CreateMap<CreateProductCommand, Product>();
            CreateMap<CreateBrandCommand, Brand>();
            CreateMap<CreateFieldInformationCommand, FieldInformation>();
            CreateMap<CreateIntelligenceRecordCommand, IntelligenceRecord>();
            CreateMap<CreateVehicleGroupCommand, VehicleGroup>();
            CreateMap<CreateVehicleTypeCommand, VehicleType>();



            CreateMap<Campaigns, HomeTopCampaignDto>();
            CreateMap<CreateCompanyCommand, Company>();
            CreateMap<CreateRoleCommand, AppRole>();
        }
    }
}
