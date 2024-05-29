namespace OnlineRivalMarket.Application.Features.CompanyFeatures.ClientIpAddresses.Commands.Create.Create
{
    public class CreateClientIpAdressCommandQueryHandler : ICommandHandler<CreateClientIpAddressCommand, CreateClientIpAddressResponse>
    {
        private readonly IClientIpAddressesService _clientIpAddressesService;
        private readonly IApiService _apiService;
        private readonly ILogService _logService;
        public CreateClientIpAdressCommandQueryHandler(IClientIpAddressesService clientIpAddressesService, IApiService apiService = null, ILogService logService = null)
        {
            _clientIpAddressesService = clientIpAddressesService;
            _apiService = apiService;
            _logService = logService;
        }

        public async Task<CreateClientIpAddressResponse> Handle(CreateClientIpAddressCommand request, CancellationToken cancellationToken)
        {
            Domain.CompanyEntities.ClientIpAddresses clientIpAddresses = await _clientIpAddressesService.CreateIpAddresAsync(request, cancellationToken);
            string userId = _apiService.GetUserIdByToken();
            Logs logs = new Logs()
            {
                Id = Guid.NewGuid().ToString(),
                TableName = nameof(ClientIpAddresses),
                Progress = "Create",
                UserId = userId,
                Data = JsonConvert.SerializeObject(clientIpAddresses)
            };
            await _logService.AddAsync(logs, request.CompanyId);
            return new();
        }
    }
}
