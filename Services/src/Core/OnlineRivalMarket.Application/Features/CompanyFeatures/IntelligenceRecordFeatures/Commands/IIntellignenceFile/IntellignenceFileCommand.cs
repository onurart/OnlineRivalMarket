namespace OnlineRivalMarket.Application.Features.CompanyFeatures.IntelligenceRecordFeatures.Commands.IIntellignenceFile;

public sealed record  IntellignenceFileCommand
                                ( 
                                 string IntelligenceRecordId,
                                 string FileUrls,string CompanyId) : ICommand<IntellignenceFileCommandResponse>;           