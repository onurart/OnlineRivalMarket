using OnlineRivalMarket.Domain.CompanyEntities;

namespace OnlineRivalMarket.Application.Features.CompanyFeatures.VehicleGroupFeaures.Queries;
public sealed record GetAllVehicleGroupQueryResponse(IList<VehicleGroup> Data);
