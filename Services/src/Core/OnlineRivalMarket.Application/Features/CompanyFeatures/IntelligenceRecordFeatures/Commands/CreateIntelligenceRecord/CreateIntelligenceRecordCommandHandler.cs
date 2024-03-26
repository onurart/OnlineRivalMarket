using Newtonsoft.Json;
using OnlineRivalMarket.Application.Messaging;
using OnlineRivalMarket.Application.Services;
using OnlineRivalMarket.Application.Services.CompanyServices;
using OnlineRivalMarket.Domain.CompanyEntities;

namespace OnlineRivalMarket.Application.Features.CompanyFeatures.IntelligenceRecordFeatures.Commands.CreateIntelligenceRecord
{
    public class CreateIntelligenceRecordCommandHandler : ICommandHandler<CreateIntelligenceRecordCommand, CreateIntelligenceRecordCommandResponse>
    {
        private readonly IIntelligenceRecordService _service;
        private readonly IApiService _apiService;
        private readonly ILogService _logService;

        public CreateIntelligenceRecordCommandHandler(IIntelligenceRecordService service, IApiService apiService, ILogService logService)
        {
            _service = service;
            _apiService = apiService;
            _logService = logService;
        }

        public async Task<CreateIntelligenceRecordCommandResponse> Handle(CreateIntelligenceRecordCommand request, CancellationToken cancellationToken)
        {
            IntelligenceRecord ıntelligenceRecord = await _service.CreateIntelligenceRecordAsync(request, cancellationToken);
            string userId = _apiService.GetUserIdByToken();
            Logs log = new()
            {
                Id = Guid.NewGuid().ToString(),
                TableName = nameof(Brand),
                Progress = "Create",
                UserId = userId,
                Data = JsonConvert.SerializeObject(ıntelligenceRecord)
            };
            await _logService.AddAsync(log, request.CompanyId);
            return new();
        }
    }
}
