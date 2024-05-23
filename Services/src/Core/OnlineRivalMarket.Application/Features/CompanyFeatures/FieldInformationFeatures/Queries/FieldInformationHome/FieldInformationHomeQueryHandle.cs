namespace OnlineRivalMarket.Application.Features.CompanyFeatures.FieldInformationFeatures.Queries.FieldInformationHome;
public sealed class FieldInformationHomeQueryHandle : IQueryHandler<FieldInformationHomeQuery, FieldInformationHomeQueryResponse>
{
    private readonly IFieldInformationService _fieldInformationService;

    public FieldInformationHomeQueryHandle(IFieldInformationService fieldInformationService)
    {
        _fieldInformationService = fieldInformationService;
    }

    public async Task<FieldInformationHomeQueryResponse> Handle(FieldInformationHomeQuery request, CancellationToken cancellationToken)
    {
        return new(await _fieldInformationService.GetAllFieldInformationHomeAsync(request));
    }
}
