namespace OnlineRivalMarket.Application.Services.CompanyServices;
public interface IIpAddresses
{
    //Task<IpAddresses> CreateIpAddresAsync(CreateIpAddresses requst, CancellationToken cancellationToken);
    Task<IList<IpAddresses>> GetAllIpAddres(string companyId);
}
