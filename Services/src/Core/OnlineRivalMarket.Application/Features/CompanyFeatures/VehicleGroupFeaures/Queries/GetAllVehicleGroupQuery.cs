namespace OnlineRivalMarket.Application.Features.CompanyFeatures.VehicleGroupFeaures.Queries;
public sealed record  GetAllVehicleGroupQuery(string CompanyId) :IQuery<GetAllVehicleGroupQueryResponse>;

