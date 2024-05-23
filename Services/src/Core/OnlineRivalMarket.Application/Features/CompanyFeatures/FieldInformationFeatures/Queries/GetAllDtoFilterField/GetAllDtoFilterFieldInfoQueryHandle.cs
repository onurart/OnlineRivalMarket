namespace OnlineRivalMarket.Application.Features.CompanyFeatures.FieldInformationFeatures.Queries.GetAllDtoFilterField;
public sealed class GetAllDtoFilterFieldInfoQueryHandle(IFieldInformationService _service) : IQueryHandler<GetAllDtoFilterFieldInfoQuery, IList<FieldInformationsesDto>>
{
    public async Task<IList<FieldInformationsesDto>> Handle(GetAllDtoFilterFieldInfoQuery request, CancellationToken cancellationToken)
    {
        var result = await _service.GetAllFieldInfoDtoFilterAsync(request.companyId, request.competitorIds, request.startDate, request.endDate,request.keyword);
        return result; //  new(result);
    }
}
