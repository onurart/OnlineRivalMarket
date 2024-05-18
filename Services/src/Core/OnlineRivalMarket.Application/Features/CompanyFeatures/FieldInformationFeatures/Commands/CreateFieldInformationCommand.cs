using Microsoft.AspNetCore.Http;
using OnlineRivalMarket.Application.Messaging;
namespace OnlineRivalMarket.Application.Features.CompanyFeatures.FieldInformationFeatures.Commands;

public sealed record CreateFieldInformationCommand
                                                  (
                                                   string CompanyId,
                                                   string CompetitorId,
                                                   string Description,
                                                   string Title,
                                                   string userId,
                                                   string UserLastName,
                                                   IFormFile[]? Files
                                                   ) : ICommand<CreateFieldInformationCommandResponse>;
