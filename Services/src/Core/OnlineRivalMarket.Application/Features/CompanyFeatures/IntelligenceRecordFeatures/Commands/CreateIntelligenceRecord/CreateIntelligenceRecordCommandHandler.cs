namespace OnlineRivalMarket.Application.Features.CompanyFeatures.IntelligenceRecordFeatures.Commands.CreateIntelligenceRecord;
public class CreateIntelligenceRecordCommandHandler : ICommandHandler<CreateIntelligenceRecordCommand, CreateIntelligenceRecordCommandResponse>
{
    private readonly IIntelligenceRecordService _service;
    private readonly IApiService _apiService;
    private readonly ILogService _logService;
    private readonly IFileService _fileService;
    private readonly IIntellignenceFileService _services;

    public CreateIntelligenceRecordCommandHandler(IIntelligenceRecordService service, IApiService apiService, ILogService logService, IFileService fileService = null, IIntellignenceFileService services = null)
    {
        _service = service;
        _apiService = apiService;
        _logService = logService;
        _fileService = fileService;
        _services = services;
    }
    public async Task<CreateIntelligenceRecordCommandResponse> Handle(CreateIntelligenceRecordCommand request, CancellationToken cancellationToken)
    {
        IntelligenceRecord ıntelligenceRecord = await _service.CreateIntelligenceRecordAsync(request, cancellationToken);
        string userId = _apiService.GetUserIdByToken();
        if(request.Files != null)
        {
            string fileUrl = @"C:\inetpub\wwwroot\build\ticket\wwwroot\TicketAttachment\OnlineRivalMarket";
            //string fileUrl = @"C:\inetpub\wwwroot\Onur";
            foreach (var file in request.Files)
            {
                string fileName = _fileService.FileSaveToServer(file,fileUrl);
                ImagesFile imagesFile = new()
                {
                    Id = Guid.NewGuid().ToString(),
                    IntelligenceRecordId = ıntelligenceRecord.Id,
                    FileUrls = fileName,
                    CreatedDate = DateTime.Now,
                };
                await _services.CreateAsync(imagesFile, request.CompanyId,cancellationToken);
            }
        }
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
