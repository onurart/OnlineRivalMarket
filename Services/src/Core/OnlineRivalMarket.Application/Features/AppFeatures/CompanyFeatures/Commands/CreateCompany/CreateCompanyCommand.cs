namespace OnlineRivalMarket.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
public sealed record CreateCompanyCommand
 (string Name,
    string Address,
    string IdentityNumber,
    string TaxDepartment,
    string Tel,
    string Email,
    string ServerName,
    string DatabaseName, 
    string ServerUserId,
    string ServerPassword, 
    string ClientApiUrl) : ICommand<CreateCompanyCommandResponse>;