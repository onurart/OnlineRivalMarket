using AutoMapper;
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using OnlineRivalMarket.Application.Features.CompanyFeatures.FieldInformationFeatures.Commands;
using OnlineRivalMarket.Application.Features.CompanyFeatures.FieldInformationFeatures.Queries.FieldInformationDto;
using OnlineRivalMarket.Application.Features.CompanyFeatures.FieldInformationFeatures.Queries.FieldInformationHome;
using OnlineRivalMarket.Application.Services.CompanyServices;
using OnlineRivalMarket.Domain;
using OnlineRivalMarket.Domain.CompanyEntities;
using OnlineRivalMarket.Domain.Dtos.FieldInformationDtos;
using OnlineRivalMarket.Domain.Dtos.IntelligenceDto;
using OnlineRivalMarket.Domain.Dtos.Product;
using OnlineRivalMarket.Domain.Repositories.CompanyDbContext.CompetitorRepository;
using OnlineRivalMarket.Domain.Repositories.CompanyDbContext.FieldInformationRepository;
using OnlineRivalMarket.Domain.UnitOfWorks;
using OnlineRivalMarket.Persistance.Context;
namespace OnlineRivalMarket.Persistance.Services.CompanyServices
{
    public sealed class FieldInformationService : IFieldInformationService
    {
        private readonly IFieldInformationCommandRepository _commandRepository;
        private readonly IFieldInformationQueryRepository _queryRepository;
        private readonly ICompanyDbUnitOfWork _unitOfWork;
        private readonly IContextService _contextService;
        private readonly ICompetitorQueryRepository _competitorQueryRepository;
        private readonly IMapper _mapper;
        private CompanyDbContext _context;
        public FieldInformationService(IFieldInformationCommandRepository commandRepository, IFieldInformationQueryRepository queryRepository, ICompanyDbUnitOfWork unitOfWork, IContextService contextService, IMapper mapper, ICompetitorQueryRepository competitorQueryRepository = null)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
            _unitOfWork = unitOfWork;
            _contextService = contextService;
            _mapper = mapper;
            _competitorQueryRepository = competitorQueryRepository;
        }
        public async Task<FieldInformation> CreateFieldInformationAsync(CreateFieldInformationCommand requset, CancellationToken cancellationToken)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(requset.CompanyId);
            _commandRepository.SetDbContextInstance(_context);
            _unitOfWork.SetDbContextInstance(_context);
            FieldInformation record = _mapper.Map<FieldInformation>(requset);
            record.Id = Guid.NewGuid().ToString();
            await _commandRepository.AddAsync(record, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return record;
        }
        public async Task<IList<FieldInformation>> GetAllFieldInformationAsync(string companyId)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId); 
            _queryRepository.SetDbContextInstance(_context);
            return await _queryRepository.GetAll().AsNoTracking().Select(p=>new FieldInformation { Id=p.Id,Title=p.Title}).ToListAsync();
        }



        public async Task<IList<FieldInformationsesDto>> GetAllFieldInformationHomeAsync(FieldInformationHomeQuery companyId)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId.CompandyId);
            _queryRepository.SetDbContextInstance(_context);
            await _queryRepository.GetAll().AsNoTracking().ToListAsync();

            var prodcustrel = await _queryRepository.GetAll().Include("Competitor").Include(x => x.FieldInformationImagesFiles).ToListAsync();
            var product = await _queryRepository.GetAll().ToListAsync();
            var joinedData = (from pc in prodcustrel
                              join p in product on pc.Id equals p.Id
                              orderby pc.CreatedDate descending
                              select new FieldInformationsesDto
                              {
                                  Id = pc.Id,
                                  CompetitorId = pc.CompetitorId,
                                  CompetitorName = p.Competitor.Name,
                                  Description = pc.Description,
                                  Title = pc.Title,
                                  CreatedDate = pc.CreatedDate,
                                  ImageFiles = pc.FieldInformationImagesFiles.Select(x => x.FieldInformationFileUrls),
                                  AppUserId = pc.UserId,
                                  AppUserName = pc.UserLastName

                              }).Take(6).ToList();
            List<FieldInformationsesDto> dto = new List<FieldInformationsesDto>();
            foreach (var item in joinedData)
            {
                dto.Add(new FieldInformationsesDto()
                {
                    Id = item.Id,
                    Title = item.Title,
                    Description = item.Description,
                    CompetitorId = item.CompetitorId,
                    CompetitorName = item.CompetitorName,
                    CreatedDate = item.CreatedDate,
                    ImageFiles = item.ImageFiles,
                    AppUserId=item.AppUserId,
                    AppUserName=item.AppUserName
                });


            }
            return dto;
        }
        public async Task<IList<FieldInformationsesDto>> GetAllFieldInformationDtoAsync(FieldInformationDtoQuery companyId)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId.CompanyId);
            _queryRepository.SetDbContextInstance(_context);
            await _queryRepository.GetAll().AsNoTracking().ToListAsync();

            var prodcustrel = await _queryRepository.GetAll().Include("Competitor").Include(x => x.FieldInformationImagesFiles).ToListAsync();
            var product = await _queryRepository.GetAll().ToListAsync();
            var joinedData = (from pc in prodcustrel
                              join p in product on pc.Id equals p.Id
                              orderby pc.CreatedDate descending
                              select new FieldInformationsesDto
                              {
                                  Id = pc.Id,
                                  CompetitorId = pc.CompetitorId,
                                  CompetitorName = pc.Competitor.Name,
                                  Description = pc.Description,
                                  Title = pc.Title,
                                  ImageFiles = pc.FieldInformationImagesFiles.Select(x => x.FieldInformationFileUrls),
                                  CreatedDate = pc.CreatedDate,
                                  AppUserId = pc.UserId,
                                  AppUserName = pc.UserLastName
                              }).ToList();
            List<FieldInformationsesDto> dto = new List<FieldInformationsesDto>();
            foreach (var item in joinedData)
            {
                dto.Add(new FieldInformationsesDto()
                {
                    Id = item.Id,
                    Title = item.Title,
                    Description = item.Description,
                    CompetitorId = item.CompetitorId,
                    CompetitorName = item.CompetitorName,
                    CreatedDate = item.CreatedDate,
                    ImageFiles = item.ImageFiles,
                    AppUserName=item.AppUserName,
                    AppUserId=item.AppUserId

                });


            }
            return dto;

        }

        public async Task<IList<FieldInformationsesDto>> GetAllFieldInformationByIdAsync(string id, string companyId)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
            _queryRepository.SetDbContextInstance(_context);
            var prodcustrel = await _queryRepository.GetWhere(x => x.Id == id).Include("Competitor").Include(x => x.FieldInformationImagesFiles).ToListAsync();
            var product = await _queryRepository.GetAll().ToListAsync();
            var joinedData = (from pc in prodcustrel
                              join p in product on pc.Id equals p.Id
                              orderby pc.CreatedDate descending
                              select new FieldInformationsesDto
                              {
                                  Id = pc.Id,
                                  CompetitorId = pc.CompetitorId,
                                  CompetitorName = pc.Competitor.Name,
                                  Description = pc.Description,
                                  Title = pc.Title,
                                  ImageFiles = pc.FieldInformationImagesFiles.Select(x => x.FieldInformationFileUrls),
                                  CreatedDate = pc.CreatedDate,
                                  AppUserId = pc.UserId,
                                  AppUserName=pc.UserLastName
                              }).ToList();
            List<FieldInformationsesDto> dto = new List<FieldInformationsesDto>();
            foreach (var item in joinedData)
            {
                dto.Add(new FieldInformationsesDto()
                {
                    Id = item.Id,
                    Title = item.Title,
                    Description = item.Description,
                    CompetitorId = item.CompetitorId,
                    CompetitorName = item.CompetitorName,
                    ImageFiles = item.ImageFiles,
                    CreatedDate = item.CreatedDate,
                    AppUserId=item.AppUserId,
                    AppUserName=item.AppUserName

                });


            }
            return dto;

        }
    }










    //public async Task<IList<FieldInformationsesDto>> GetAllFieldInformationByIdAsync(string id, string companyId)
    //{
    //    _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
    //    _queryRepository.SetDbContextInstance(_context);
    //    _queryProductRepository.SetDbContextInstance(_context);
    //    var intelligence = await _queryRepository.GetWhere(x => x.Id == id, false).Include("Competitor").Include(x=>x.).ToListAsync();
    //    var product = await _queryProductRepository.GetAll().Include("VehicleType").Include("VehicleGrup").Include("Brand").Include("Category").ToListAsync();
    //    var joinedData = (from pc in intelligence
    //                      join p in product on pc.ProductId equals p.Id
    //                      orderby pc.CreatedDate descending
    //                      select new IntelligenceByIdDto
    //                      {
    //                          Id = pc.Id,
    //                          CompetitorId = pc.CompetitorId,
    //                          CompetitorName = pc.Competitor != null ? pc.Competitor.Name : null,
    //                          BrandId = p.BrandId,
    //                          BrandName = p.Brand.Name,
    //                          CategoryId = p.CategoryId,
    //                          CategoryName = p.Category.Name,
    //                          ProductId = p.Id,
    //                          ProductName = p.ProductName,
    //                          Description = pc.Description,
    //                          VehicleGroupId = p.VehicleGrup.Id,
    //                          VehicleGroupName = p.VehicleGrup.Name,
    //                          VehicleTypeId = p.VehicleType.Id,
    //                          VehicleTypeName = p.VehicleType.Name,
    //                          MCurrency = pc.MCurrency,
    //                          RakipCurrency = pc.RakipCurrency,
    //                          ForeignCurrencyId = pc.ForeignCurrencyId,
    //                          ForeignCurrencyName = pc.ForeignCurrency.CurrencyName,
    //                          ImageFiles = pc.IntelligenceRecordFiles.Select(x => x.FileUrls)
    //                      }).Take(5).ToList();
    //    List<FieldInformationsesDto> dtos = new List<FieldInformationsesDto>();
    //    foreach (var d in joinedData)
    //    {
    //        dtos.Add(new FieldInformationsesDto()
    //        {
    //            ImageFiles = d.ImageFiles,
    //            CompetitorId=d.CompetitorId,
    //            CompetitorName=d.CompetitorName,
    //            Description = d.Description,    
    //            Title = d.Title,
    //            CreatedDate = d.CreatedDate,    
    //            Id=id,
    //        });
    //    }
    //    return dtos;
    //}
}

