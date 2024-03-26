using OnlineRivalMarket.Application.Messaging;
namespace OnlineRivalMarket.Application.Features.CompanyFeatures.CategoryFeatures.Commands.CreateCategory;
public sealed record CreateCategoryCommand
                                        (string Name ,string CompanyId) :ICommand<CreateCategoryCommandResponse>;
