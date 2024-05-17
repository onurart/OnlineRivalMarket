using OnlineRivalMarket.Application.Messaging;

namespace OnlineRivalMarket.Application.Features.CompanyFeatures.FieldInformationFeatures.Queries.FieldInformationDto;
public sealed record FieldInformationDtoQuery(string CompanyId) : IQuery<FieldInformationDtoQueryResponse>;
