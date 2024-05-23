namespace OnlineRivalMarket.Application.Features.CompanyFeatures.IntelligenceRecordFeatures.Commands.CreateIntelligenceRecord;
public sealed record CreateIntelligenceRecordCommand
                                                  (
                                                        string? CompanyId,
                                                        string? CompetitorId,
                                                        string? ProductId,
                                                        string? Description,
                                                        decimal? MCurrency,
                                                        decimal? RakipCurrency,
                                                        string? ForeignCurrencyId,
                                                         string userId,
                                                         string UserLastName,
                                                        IFormFile[]? Files
                                                        ) : ICommand<CreateIntelligenceRecordCommandResponse>;