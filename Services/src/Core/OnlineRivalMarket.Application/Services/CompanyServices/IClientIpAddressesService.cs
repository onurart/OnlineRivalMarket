using OnlineRivalMarket.Application.Features.CompanyFeatures.ClientIpAddresses.Commands.Create.Create;

namespace OnlineRivalMarket.Application.Services.CompanyServices;
public interface IClientIpAddressesService
{
    Task<ClientIpAddresses> CreateIpAddresAsync(CreateClientIpAddressCommand request, CancellationToken cancellationToken);
    Task<IList<ClientIpAddresses>> GetAllIpAddres(string companyId);
    Task<ClientIpAddresses> GetByIdAsync(DateTime? UpdatedDate, string id, string companyId);
}
