namespace OnlineRivalMarket.Application.Features.CompanyFeatures.VehicleTypeFeaures.Queries.GetAllVehicleType;
public sealed record class GetAllVehicleTypeQuery(string CompanyId) : IQuery<GetAllVehicleTypeQueryResponse>;
