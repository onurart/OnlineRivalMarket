using OnlineRivalMarket.Application.Messaging;
using OnlineRivalMarket.Domain.Dtos.FieldInformationDtos;
namespace OnlineRivalMarket.Application.Features.CompanyFeatures.FieldInformationFeatures.Queries.GetAllDtoFilterField;
public sealed record GetAllDtoFilterFieldInfoQuery(string companyId, List<string> competitorIds, DateTime? startDate, DateTime? endDate, string keyword) : IQuery<IList<FieldInformationsesDto>>;
