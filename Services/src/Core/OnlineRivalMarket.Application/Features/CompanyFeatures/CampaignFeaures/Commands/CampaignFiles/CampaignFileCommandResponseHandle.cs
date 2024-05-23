namespace OnlineRivalMarket.Application.Features.CompanyFeatures.CampaignFeaures.Commands.CampaignFiles;
public sealed class CampaignFileCommandResponseHandle : ICommandHandler<CampaignFileCommand, CampaignFileCommandResponse>
{
    private readonly ICampaingFileService _service;
    public CampaignFileCommandResponseHandle(ICampaingFileService service)
    {
        _service = service;
    }
    public Task<CampaignFileCommandResponse> Handle(CampaignFileCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
