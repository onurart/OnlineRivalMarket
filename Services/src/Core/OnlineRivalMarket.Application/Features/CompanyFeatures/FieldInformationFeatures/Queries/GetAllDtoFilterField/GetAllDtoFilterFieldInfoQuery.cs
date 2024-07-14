namespace OnlineRivalMarket.Application.Features.CompanyFeatures.FieldInformationFeatures.Queries.GetAllDtoFilterField
{
	public sealed record GetAllDtoFilterFieldInfoQuery(
		string companyId,
		List<string> competitorIds,
		DateTime? startDate,
		DateTime? endDate,
		string keyword,
		int PageNumber = 1,
		int PageSize = 10) : IQuery<FieldInformationseResponse>;
}


