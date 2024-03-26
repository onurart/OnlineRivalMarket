using OnlineRivalMarket.Application.Messaging;
namespace OnlineRivalMarket.Application.Features.CompanyFeatures.BrandFeaures.Commands.CreateBrand;
public sealed record  CreateBrandCommand
                                            (string Name, string? CompanyId) : ICommand<CreateBrandCOmmandResponse>
{
}
