using OnlineRivalMarket.Application.Messaging;
using OnlineRivalMarket.Domain.Enums;

namespace OnlineRivalMarket.Application.Features.CompanyFeatures.IntelligenceRecordFeatures.Commands.CreateIntelligenceRecord;
public sealed record CreateIntelligenceRecordCommand
                                                  (
                                                        string? CompanyId,
                                                        string? CompetitorsId,
                                                        IntelligenceType Specieses,
                                                        string? BrandId,
                                                        string? CategoryId,
                                                        string? ProductId,
                                                        string? Description,
                                                        string? ImageUrl,
                                                        string? Location,
                                                        Region? Region,
                                                        string? VehicleType,
                                                        string? VehicleGroup,
                                                        string? FieldFeedback,
                                                        decimal? CurrencyDolor,
                                                        decimal? CurrencyEuro,
                                                        decimal? CurrencyTl,
                                                        decimal? RakipDolor,
                                                        decimal? RakipEuro,
                                                        decimal? RakipTl
                                                   ) : ICommand<CreateIntelligenceRecordCommandResponse>;