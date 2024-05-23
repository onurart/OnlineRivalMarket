namespace OnlineRivalMarket.Application.Services.CompanyServices;
public interface ILdapService
{
    Task<LdapUserDtos> GetAllUser();
    Task<Result<LdapUserDto>> Login(string usernameandemail, string password);
}
