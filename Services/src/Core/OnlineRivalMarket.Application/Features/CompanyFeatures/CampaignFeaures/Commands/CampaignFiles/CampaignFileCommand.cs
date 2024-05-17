using OnlineRivalMarket.Application.Messaging;

namespace OnlineRivalMarket.Application.Features.CompanyFeatures.CampaignFeaures.Commands.CampaignFiles;

public sealed record CampaignFileCommand(string CompaingId,string FileUrl,string CompanyId) : ICommand<CampaignFileCommandResponse>;
