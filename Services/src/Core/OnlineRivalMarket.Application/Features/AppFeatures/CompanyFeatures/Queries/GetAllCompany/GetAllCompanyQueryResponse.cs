using OnlineRivalMarket.Domain.AppEntities;
namespace OnlineRivalMarket.Application.Features.AppFeatures.CompanyFeatures.Queries.GetAllCompany;
public sealed record GetAllCompanyQueryResponse(List<Company> Companies);