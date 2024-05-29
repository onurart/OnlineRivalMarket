using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRivalMarket.Application.Features.CompanyFeatures.ClientIpAddresses.Commands.Create.UpdateProduct
{
    public sealed class UpdatedDateHandle : ICommandHandler<UpdatedDateCommand, UpdateDateResponse>
    {
        private readonly IClientIpAddressesService _clientIpAddressesService;

        public UpdatedDateHandle(IClientIpAddressesService clientIpAddressesService)
        {
            _clientIpAddressesService = clientIpAddressesService;
        }

        public async Task<UpdateDateResponse> Handle(UpdatedDateCommand request, CancellationToken cancellationToken)
        {
            OnlineRivalMarket.Domain.CompanyEntities.ClientIpAddresses clienta = await _clientIpAddressesService.GetByIdAsync(request.UpdatedDate,request.Id,request.companyId);
            return new();
        }
    }
}
