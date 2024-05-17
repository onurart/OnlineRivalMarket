using OnlineRivalMarket.Application.Messaging;
namespace OnlineRivalMarket.Application.Features.CompanyFeatures.FieldInformationFeatures.Queries.FieldInformationById;
public sealed record  FieldInformationByIdQuery(string id,string CompanyId) : IQuery<FieldInformationByIdQueryResponse>;