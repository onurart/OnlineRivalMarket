namespace OnlineRivalMarket.Application.Features.CompanyFeatures.BrandFeaures.Commands.Queries.GetAllBrand;
public sealed record GetAllBrandQuery(string CompanyId): IQuery<GetAllBrandQueryResponse>;
