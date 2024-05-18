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
        private readonly ICFFileService _fileService;
        private readonly  ICFFieldFileService _services;

        public CreateFieldInformationCommandHandler(ILogService logService, IApiService apiService, IFieldInformationService fieldInformationService, ICFFileService fileService = null, ICFFieldFileService services = null)
        {
            _logService = logService;
            _apiService = apiService;
            _fieldInformationService = fieldInformationService;
            _fileService = fileService;
            _services = services;
        }
        public async Task<CreateFieldInformationCommandResponse> Handle(CreateFieldInformationCommand request, CancellationToken cancellationToken)
        {
            //FieldInformation fieldInformation=new (){
            
            //};



        
            FieldInformation newFieldInformation = await _fieldInformationService.CreateFieldInformationAsync(request, cancellationToken);
            string userId = _apiService.GetUserIdByToken();
            if (request.Files != null)
            {
                //string fileUrl = @"C:\inetpub\wwwroot\build\ticket\wwwroot\TicketAttachment\OnlineRivalMarket\FieldInformation";
                string fileUrl = @"C:\inetpub\wwwroot\Onur\FieldInformation";
                foreach (var file in request.Files)
                {
                    string fileName = _fileService.FileSaveToServer(file, fileUrl);
                    FieldInformationImagesFile imagesFile = new()
                    {
                        Id = Guid.NewGuid().ToString(),
                        FieldInformationId=newFieldInformation.Id,
                        FieldInformationFileUrls = fileName,
                        CreatedDate = DateTime.Now,
                    };
                    await _services.CreateAsync(imagesFile, request.CompanyId, cancellationToken);
                }
            }
            Logs log = new()
            {
                Id = Guid.NewGuid().ToString(),
                TableName = nameof(FieldInformation),
                Progress = "Create",
                UserId = userId,
                Data = JsonConvert.SerializeObject(newFieldInformation)
            };
            await _logService.AddAsync(log, request.CompanyId);
            return new();
        }
    }
}
