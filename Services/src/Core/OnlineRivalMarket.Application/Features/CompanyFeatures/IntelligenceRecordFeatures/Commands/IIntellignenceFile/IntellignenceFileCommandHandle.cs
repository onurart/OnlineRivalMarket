using OnlineRivalMarket.Application.Messaging;
using OnlineRivalMarket.Application.Services.CompanyServices;
using OnlineRivalMarket.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineRivalMarket.Domain.CompanyEntities;
using Newtonsoft.Json;

namespace OnlineRivalMarket.Application.Features.CompanyFeatures.IntelligenceRecordFeatures.Commands.IIntellignenceFile
{
    public sealed class IntellignenceFileCommandHandle : ICommandHandler<IntellignenceFileCommand, IntellignenceFileCommandResponse>
    {
        private readonly IApiService _apiService;
        private readonly ILogService _logService;
        private readonly IIntellignenceFileService _service;

        public IntellignenceFileCommandHandle(IApiService apiService, ILogService logService, IIntellignenceFileService service)
        {
            _apiService = apiService;
            _logService = logService;
            _service = service;
        }

        public async Task<IntellignenceFileCommandResponse> Handle(IntellignenceFileCommand request, CancellationToken cancellationToken)
        {
          throw new NotImplementedException();
        }
    }
}
