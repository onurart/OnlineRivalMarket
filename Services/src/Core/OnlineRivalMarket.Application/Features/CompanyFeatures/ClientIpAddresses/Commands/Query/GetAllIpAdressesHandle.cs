
namespace OnlineRivalMarket.Application.Features.CompanyFeatures.ClientIpAddresses.Commands.Query;
public sealed class GetAllIpAdressesHandle : IQueryHandler<GetlAllIpAdressesQuery, GetAllIpAdressesResponse>
{
    private readonly IClientIpAddressesService _clientIpAddressesService;

    public GetAllIpAdressesHandle(IClientIpAddressesService clientIpAddressesService)
    {
        _clientIpAddressesService = clientIpAddressesService;
    }

    public async Task<GetAllIpAdressesResponse> Handle(GetlAllIpAdressesQuery request, CancellationToken cancellationToken)
    {
        return new(await _clientIpAddressesService.GetAllIpAddres(request.CompanyId));
    }
}
