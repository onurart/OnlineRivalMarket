namespace OnlineRivalMarket.Application.Services.CompanyServices;
public interface IIntellignenceFileService
{
    Task<ImagesFile> CreateAsync(ImagesFile ımagesFile,string companyid, CancellationToken cancellationToken);
    IQueryable<ImagesFile> GetAll(string companyId);
    Task UpdateAsync(ImagesFile ticketFile);
    Task RemoveByIdAsync(string id);
}