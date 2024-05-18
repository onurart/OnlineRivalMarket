using Microsoft.AspNetCore.Http;
using OnlineRivalMarket.Application.Messaging;
namespace OnlineRivalMarket.Application.Features.CompanyFeatures.CampaignFeaures.Commands.CreateCampaign;
public sealed record CreateCampaignCommand
                                         (
                                           string? CompetitorId,

                                           string? ProductId,

                                           DateTime? StartTime,

                                           DateTime? EndTime,

                                           string? Description,
                                           string? CompanyId,
                                            string userId,
                                            string UserLastName,
                                            IFormFile[]? Files
                                         ) : ICommand<CreateCampaignCommandResponse>;

