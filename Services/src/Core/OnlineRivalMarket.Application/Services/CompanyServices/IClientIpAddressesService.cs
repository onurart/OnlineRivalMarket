namespace OnlineRivalMarket.Application.Services.CompanyServices;
public interface IClientIpAddressesService
{
    Task<ClientIpAddresses> CreateIpAddresAsync(CreateClientIpAddressCommand request, CancellationToken cancellationToken);
    Task<ClientIpAddresses> GetByIdAsync(DateTime? UpdatedDate, string id, string companyId);
    Task<IList<ClientIpAddresses>> GetAllIpAddres(string companyId);
}