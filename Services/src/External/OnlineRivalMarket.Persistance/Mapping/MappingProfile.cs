namespace OnlineRivalMarket.Persistance.Mapping;
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
        CreateMap<CreateForeignCurrencyCommand, ForeignCurrency>();
        CreateMap<CreateClientIpAddressCommand ,ClientIpAddresses>();
        CreateMap<Campaigns, HomeTopCampaignDto>();
        CreateMap<CreateCompanyCommand, Company>();
        CreateMap<CreateRoleCommand, AppRole>();
    }
}