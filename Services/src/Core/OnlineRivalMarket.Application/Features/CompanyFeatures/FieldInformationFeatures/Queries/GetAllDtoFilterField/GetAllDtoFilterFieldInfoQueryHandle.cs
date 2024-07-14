
namespace OnlineRivalMarket.Application.Features.CompanyFeatures.FieldInformationFeatures.Queries.GetAllDtoFilterField;
public sealed class GetAllDtoFilterFieldInfoQueryHandle : IQueryHandler<GetAllDtoFilterFieldInfoQuery, FieldInformationseResponse>
{
	private readonly IFieldInformationService _service;

	public GetAllDtoFilterFieldInfoQueryHandle(IFieldInformationService service)
	{
		_service = service;
	}
	public async Task<FieldInformationseResponse> Handle(GetAllDtoFilterFieldInfoQuery request, CancellationToken cancellationToken)
	{
		var result = await _service.GetAllFieldInfoDtoFilterAsync(
			request.companyId,
			request.competitorIds,
			request.startDate,
			request.endDate,
			request.PageNumber,
			request.PageSize,
			request.keyword);
		return new FieldInformationseResponse(result);
	}
}



