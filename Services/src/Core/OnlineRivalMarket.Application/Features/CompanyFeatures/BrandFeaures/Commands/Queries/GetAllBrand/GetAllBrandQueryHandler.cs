using OnlineRivalMarket.Application.Messaging;
using OnlineRivalMarket.Application.Services.CompanyServices;
namespace OnlineRivalMarket.Application.Features.CompanyFeatures.BrandFeaures.Commands.Queries.GetAllBrand;
public sealed class GetAllBrandQueryHandler : IQueryHandler<GetAllBrandQuery, GetAllBrandQueryResponse>
{
    private readonly IBrandService _brandService;

    public GetAllBrandQueryHandler(IBrandService brandService)
    {
        _brandService = brandService;
    }
    public async Task<GetAllBrandQueryResponse> Handle(GetAllBrandQuery request, CancellationToken cancellationToken)
    {
        return new(await _brandService.GetAllBrandsAsync(request.CompanyId));
    }
}