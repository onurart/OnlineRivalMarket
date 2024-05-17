using OnlineRivalMarket.Domain.CompanyEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRivalMarket.Application.Services.CompanyServices
{
    public interface ICFFieldFileService
    {
        Task<FieldInformationImagesFile> CreateAsync(FieldInformationImagesFile imagesFile, string companyid, CancellationToken cancellationToken);
        IQueryable<FieldInformationImagesFile> GetAll(string companyId);
        Task UpdateAsync(FieldInformationImagesFile ticketFile);
        Task RemoveByIdAsync(string id);
    }
}
