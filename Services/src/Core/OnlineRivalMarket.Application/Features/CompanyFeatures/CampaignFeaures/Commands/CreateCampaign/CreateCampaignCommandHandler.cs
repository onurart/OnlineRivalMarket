using Newtonsoft.Json;
using OnlineRivalMarket.Application.Messaging;
using OnlineRivalMarket.Application.Services.CompanyServices;
using OnlineRivalMarket.Application.Services;
using OnlineRivalMarket.Domain.CompanyEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineRivalMarket.Application.Services.CompanyServices;

namespace OnlineRivalMarket.Application.Features.CompanyFeatures.CampaignFeaures.Commands.CreateCampaign;
public sealed class CreateCampaignCommandHandler : ICommandHandler<CreateCampaignCommand, CreateCampaignCommandResponse>
{
    private readonly ICampaignService _campaignService;
    private readonly IApiService _apiService;
    private readonly ILogService _logService;

    public CreateCampaignCommandHandler(ICampaignService campaignService, IApiService apiService, ILogService logService)
    {
        _campaignService = campaignService;
        _apiService = apiService;
        _logService = logService;
    }

    public async Task<CreateCampaignCommandResponse> Handle(CreateCampaignCommand request, CancellationToken cancellationToken)
    {
        Campaigns createBrand = await _campaignService.CreateCampaignAsync(request, cancellationToken);
        string userId = _apiService.GetUserIdByToken();
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
