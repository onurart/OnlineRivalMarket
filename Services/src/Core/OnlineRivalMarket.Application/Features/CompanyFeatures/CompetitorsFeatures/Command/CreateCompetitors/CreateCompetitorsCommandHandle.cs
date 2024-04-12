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

namespace OnlineRivalMarket.Application.Features.CompanyFeatures.CompetitorsFeatures.Command.CreateCompetitors
{
    public class CreateCompetitorsCommandHandle : ICommandHandler<CreateCompetitorsCommand, CreateCompetitorsCommandResponse>
    {
        private readonly IApiService _apiService;
        private readonly ILogService _servicelog;
        private readonly ICompetitorService _competitorService;

        public CreateCompetitorsCommandHandle(IApiService apiService, ILogService servicelog, ICompetitorService competitorService)
        {
            _apiService = apiService;
            _servicelog = servicelog;
            _competitorService = competitorService;
        }

        public async Task<CreateCompetitorsCommandResponse> Handle(CreateCompetitorsCommand request, CancellationToken cancellationToken)
        {
            Competitor createBrand = await _competitorService.CreateCompetitorsAsync(request, cancellationToken);
            string userId = _apiService.GetUserIdByToken();
            Logs log = new()
            {
                Id = Guid.NewGuid().ToString(),
                TableName = nameof(Brand),
                Progress = "Create",
                UserId = userId,
                Data = JsonConvert.SerializeObject(createBrand)
            };
            await _servicelog.AddAsync(log, request.companyId);
            return new();
        }
    }
}
