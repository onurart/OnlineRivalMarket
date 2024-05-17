using Microsoft.AspNetCore.Http;
using OnlineRivalMarket.Application.Messaging;
using OnlineRivalMarket.Domain.Enums;

namespace OnlineRivalMarket.Application.Features.CompanyFeatures.IntelligenceRecordFeatures.Commands.CreateIntelligenceRecord;
public sealed record CreateIntelligenceRecordCommand
                                                  (
                                                        string? CompanyId,
                                                        string? CompetitorId,
                                                        string? ProductId,
                                                        string? Description,
                                                        //string? Location,
                                                        //IntelligenceType IntelligenceType,
                                                        //Region? Region,
                                                        //string? FieldFeedback,        
                                                        //string? Explanation,
                                                        decimal? MCurrency,
                                                        decimal? RakipCurrency,
                                                        string? ForeignCurrencyId,
                                                        IFormFile[]? Files
                                                        ) : ICommand<CreateIntelligenceRecordCommandResponse>;