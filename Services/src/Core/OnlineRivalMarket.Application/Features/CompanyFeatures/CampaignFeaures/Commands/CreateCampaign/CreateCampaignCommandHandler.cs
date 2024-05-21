using Newtonsoft.Json;
using OnlineRivalMarket.Application.Messaging;
using OnlineRivalMarket.Application.Services;
using OnlineRivalMarket.Application.Services.CompanyServices;
using OnlineRivalMarket.Domain.CompanyEntities;

namespace OnlineRivalMarket.Application.Features.CompanyFeatures.CampaignFeaures.Commands.CreateCampaign;
public sealed class CreateCampaignCommandHandler : ICommandHandler<CreateCampaignCommand, CreateCampaignCommandResponse>
{
    private readonly ICampaignService _campaignService;
    private readonly IApiService _apiService;
    private readonly ILogService _logService;
    private readonly ICFİleService _cfleService;
    private readonly ICampaingFileService _campaingFileService;
    public CreateCampaignCommandHandler(ICampaignService campaignService, IApiService apiService, ILogService logService, ICampaingFileService campaingFileService = null, ICFİleService cfleService = null)
    {
        _campaignService = campaignService;
        _apiService = apiService;
        _logService = logService;
        _campaingFileService = campaingFileService;
        _cfleService = cfleService;
    }

    public async Task<CreateCampaignCommandResponse> Handle(CreateCampaignCommand request, CancellationToken cancellationToken)
    {
        Campaigns createBrand = await _campaignService.CreateCampaignAsync(request, cancellationToken);
        string userId = _apiService.GetUserIdByToken();
        if (request.Files != null)
        {
            string fileUrl = @"C:\inetpub\wwwroot\build\ticket\wwwroot\TicketAttachment\OnlineRivalMarket\Campaing";
            //string fileUrl = @"C:\inetpub\wwwroot\Onur\Campaing";
            foreach (var file in request.Files)
            {
                string fileName = _cfleService.FileSaveToServer(file, fileUrl);
                CampaingImagesFile campaingImagesFile = new()
                {
                    Id = Guid.NewGuid().ToString(),
                    CampaignsId = createBrand.Id,
                    CampaingFİleUrls = fileName,
                    CreatedDate = DateTime.Now,
                };
                await _campaingFileService.CreateAsync(campaingImagesFile, request.CompanyId, cancellationToken);
            }
        }
        Logs log = new()
        {
            Id = Guid.NewGuid().ToString(),
            TableName = nameof(Brand),
            Progress = "Create",
            UserId = userId,
            Data = JsonConvert.SerializeObject(createBrand)
        };
        await _logService.AddAsync(log, request.CompanyId);
        return new();
    }
}
