using OnlineRivalMarket.Application.Messaging;

namespace OnlineRivalMarket.Application.Features.CompanyFeatures.FieldInformationFeatures.Queries;
public sealed record GetAllFieldInformationQuery(string CompanyId) : IQuery<GetAllFieldInformationQueryReponse>;
