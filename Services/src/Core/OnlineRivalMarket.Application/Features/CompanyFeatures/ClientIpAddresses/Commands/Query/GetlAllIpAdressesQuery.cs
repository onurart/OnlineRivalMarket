namespace OnlineRivalMarket.Application.Features.CompanyFeatures.ClientIpAddresses.Commands.Query;
public sealed record GetlAllIpAdressesQuery(string CompanyId) : IQuery<GetAllIpAdressesResponse>;

