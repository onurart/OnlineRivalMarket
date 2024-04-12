using OnlineRivalMarket.Application.Messaging;
using OnlineRivalMarket.Domain.Enums;

namespace OnlineRivalMarket.Application.Features.CompanyFeatures.IntelligenceRecordFeatures.Commands.CreateIntelligenceRecord;
public sealed record CreateIntelligenceRecordCommand
                                                  (
                                                        string? CompanyId,
                                                        string? CompetitorsId,
                                                        string? ProductId,
                                                        IntelligenceType Specieses,
                                                        string? Description,
                                                        string? ImageUrl,
                                                        string? Location,
                                                        Region? Region,
                                                        string? FieldFeedback,                                                        
                                                        decimal? CurrencyDolor,
                                                        decimal? CurrencyEuro,
                                                        decimal? CurrencyTl,
                                                        decimal? RakipDolor,
                                                        decimal? RakipEuro,
                                                        decimal? RakipTl
                                                   ) : ICommand<CreateIntelligenceRecordCommandResponse>;