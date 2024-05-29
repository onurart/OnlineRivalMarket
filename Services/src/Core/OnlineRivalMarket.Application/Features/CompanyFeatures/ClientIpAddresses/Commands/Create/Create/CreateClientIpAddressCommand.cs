namespace OnlineRivalMarket.Application.Features.CompanyFeatures.ClientIpAddresses.Commands.Create.Create;
public sealed record CreateClientIpAddressCommand
                                                (string? CompanyId,
                                                 string? UserName,
                                                 string? UserEmail,
                                                 string? UserLastName,
                                                 string? Latitude,
                                                 string? Longitude) : ICommand<CreateClientIpAddressResponse>;
