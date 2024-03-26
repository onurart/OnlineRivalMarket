using Newtonsoft.Json;
using OnlineRivalMarket.Application.Messaging;
using OnlineRivalMarket.Application.Services;
using OnlineRivalMarket.Application.Services.CompanyServices;
using OnlineRivalMarket.Domain.CompanyEntities;
namespace OnlineRivalMarket.Application.Features.CompanyFeatures.FieldInformationFeatures.Commands
{
    public sealed class CreateFieldInformationCommandHandler : ICommandHandler<CreateFieldInformationCommand, CreateFieldInformationCommandResponse>
    {
        private readonly ILogService _logService;
        private readonly IApiService _apiService;
        private readonly IFieldInformationService _fieldInformationService;

        public CreateFieldInformationCommandHandler(ILogService logService, IApiService apiService, IFieldInformationService fieldInformationService)
        {
            _logService = logService;
            _apiService = apiService;
            _fieldInformationService = fieldInformationService;
        }
        public async Task<CreateFieldInformationCommandResponse> Handle(CreateFieldInformationCommand request, CancellationToken cancellationToken)
        {
            FieldInformation newFieldInformation = await _fieldInformationService.CreateFieldInformationAsync(request, cancellationToken);
            string userId = _apiService.GetUserIdByToken();
            Logs log = new()
            {
                Id = Guid.NewGuid().ToString(),
                TableName = nameof(Brand),
                Progress = "Create",
                UserId = userId,
                Data = JsonConvert.SerializeObject(newFieldInformation)
            };
            await _logService.AddAsync(log, request.companyId);
            return new();
        }
    }
}
