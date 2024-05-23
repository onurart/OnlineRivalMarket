namespace OnlineRivalMarket.Application.Features.CompanyFeatures.FieldInformationFeatures.Queries;
public sealed class GetAllFieldInformationQueryHandler : IQueryHandler<GetAllFieldInformationQuery, GetAllFieldInformationQueryReponse>
{
    private readonly IFieldInformationService _fieldInformationService;
    public GetAllFieldInformationQueryHandler(IFieldInformationService fieldInformationService)
    {
        _fieldInformationService = fieldInformationService;
    }
    public async Task<GetAllFieldInformationQueryReponse> Handle(GetAllFieldInformationQuery requst, CancellationToken cancellationToken)
    {
        return new(await _fieldInformationService.GetAllFieldInformationAsync(requst.CompanyId));
    }
}
