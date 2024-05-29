namespace OnlineRivalMarket.Application.Features.CompanyFeatures.ClientIpAddresses.Commands.Create.UpdateProduct;
public sealed record UpdatedDateCommand
                                       (
                                        string Id,
                                        string companyId,
                                        DateTime? UpdatedDate) : ICommand<UpdateDateResponse>;
