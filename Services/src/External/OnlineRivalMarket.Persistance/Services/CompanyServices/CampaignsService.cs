using AutoMapper;
using OnlineRivalMarket.Application.Services.CompanyServices;
using Microsoft.EntityFrameworkCore;
using OnlineRivalMarket.Application.Features.CompanyFeatures.CampaignFeaures.Commands.CreateCampaign;
using OnlineRivalMarket.Domain;
using OnlineRivalMarket.Domain.CompanyEntities;
using OnlineRivalMarket.Domain.Repositories.CompanyDbContext.CampaignRepository;
using OnlineRivalMarket.Domain.UnitOfWorks;
using OnlineRivalMarket.Persistance.Context;
using OnlineRivalMarket.Domain.Dtos.HomeTopDto;
using OnlineRivalMarket.Persistance.Repositories.CompanyDbContext.CampaignRepository;
using OnlineRivalMarket.Domain.Dtos;
using OnlineRivalMarket.Domain.Repositories.CompanyDbContext.ProductRepositories;
using System.Collections.Immutable;
namespace OnlineRivalMarket.Persistance.Services.CompanyServices
{
    public sealed class CampaignsService : ICampaignService
    {
        private readonly ICampaignCommandRepository _commandRepository;
        private readonly ICampaignQueryRepository _queryRepository;
        private readonly IContextService _contextService;
        private readonly ICompanyDbUnitOfWork _companyDbUnitOfWork;
        private readonly IProductQueryRepository _queryProductRepository;

        private readonly IMapper _mapper;
        private CompanyDbContext _context;

        public CampaignsService(ICampaignCommandRepository commandRepository, ICampaignQueryRepository queryRepository, IContextService contextService, ICompanyDbUnitOfWork companyDbUnitOfWork, IMapper mapper, IProductQueryRepository queryProductRepository = null)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
            _contextService = contextService;
            _companyDbUnitOfWork = companyDbUnitOfWork;
            _mapper = mapper;
            _queryProductRepository = queryProductRepository;
        }
      
        
        
        
        
        public async Task<Campaigns> CreateCampaignAsync(CreateCampaignCommand request, CancellationToken cancellationToken)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
            _commandRepository.SetDbContextInstance(_context);
            _companyDbUnitOfWork.SetDbContextInstance(_context);
            Campaigns campaigns = _mapper.Map<Campaigns>(request);
            campaigns.Id = Guid.NewGuid().ToString();
            await _commandRepository.AddAsync(campaigns, cancellationToken);
            await _companyDbUnitOfWork.SaveChangesAsync(cancellationToken);
            return campaigns;
            }
        
        
        
        
        public async Task<IList<Campaigns>> GetAllAsync(string companyId)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
            _queryRepository.SetDbContextInstance(_context);
            return await _queryRepository.GetAll().AsNoTracking().ToListAsync();
        }

        public async Task<IList<HomeTopCampaignDto>> HomeTopGetAllDtoAsync(string companyId)
        {
            //_context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
            //_queryRepository.SetDbContextInstance(_context);
            //_queryProductRepository.SetDbContextInstance(_context);
            //var prodcustrel = await _queryRepository.GetAll().Include("Competitor").Include("Product").ToListAsync();
            //var product = await _queryProductRepository.GetAll().Include("Category").Include("Brand").ToListAsync();

            //var joinedData = (from pc in prodcustrel
            //                  join p in product on pc.ProductId equals p.Id
            //                  orderby pc.CreatedDate descending
            //                  select new HomeTopCampaignDto
            //                  {
            //                      CompetitorId = pc.CompetitorId,
            //                      CompetitorsesName = pc.Competitor.Name,

            //                      BrandId = p.BrandId,
            //                      BrandName = p.Brand.Name,

            //                      CategoryId = p.CategoryId,
            //                      CategoryName = p.Category.Name,

            //                      ProductId = pc.Product.Id,
            //                      ProductName = pc.Product.ProductName,
                                  
            //                      Description = pc.Description,    
            //                      StartTime = pc.StartTime,
            //                      ImageUrl = pc.ImageUrl,
            //                      EndTime=pc.EndTime
            //                  }).ToList();

            //List<HomeTopCampaignDto> dto = new();
            //foreach (var item in joinedData)
            //{
            //    dto.Add(new HomeTopCampaignDto()
            //    {
            //        CompetitorId = item.CompetitorId,
            //        CompetitorsesName = item.CompetitorsesName,

            //        BrandId = item.BrandId,
            //        BrandName = item.BrandName,

            //        CategoryId = item.CategoryId,
            //        CategoryName = item.CategoryName,

            //        ProductId = item.ProductId,
            //        ProductName = item.ProductName,

            //        Description = item.Description,
            //        EndTime = item.EndTime,
            //       ImageUrl = item.ImageUrl,
            //       StartTime = item.StartTime

            //    });
            //}
            //return dto.ToList();
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
            _queryRepository.SetDbContextInstance(_context);
            _queryProductRepository.SetDbContextInstance(_context);
            var prodcustrel = await _queryRepository.GetAll().Include("Competitor").Include("Product").ToListAsync();
            var product = await _queryProductRepository.GetAll().Include("Category").Include("Brand").ToListAsync();

            var joinedData = (from pc in prodcustrel
                              join p in product on pc.ProductId equals p.Id
                              orderby pc.CreatedDate descending
                              select new HomeTopCampaignDto
                              {
                                  CompetitorId = pc.CompetitorId,
                                  // CompetitorsesName = pc.Competitors != null ? pc.Competitors.Name : null,
                                  BrandId = p.BrandId,
                                  BrandName = p.Brand.Name,
                                  CategoryId = p.CategoryId,
                                  CategoryName = p.Category.Name,
                                  ProductId = p.Id,
                                  ProductName = p.ProductName,
                                  Description = pc.Description,

                                  ImageUrl = pc.ImageUrl,
                              }).Take(5).ToList();

            List<HomeTopCampaignDto> dto = new();
            foreach (var item in joinedData)
            {
                dto.Add(new HomeTopCampaignDto()
                {
                    CompetitorId = item.CompetitorId,
                    CompetitorsesName = item.CompetitorsesName,
                    BrandId = item.BrandId,
                    BrandName = item.BrandName,
                    CategoryId = item.CategoryId,
                    CategoryName = item.CategoryName,
                    ProductId = item.ProductId,
                    ProductName = item.ProductName,
                    ImageUrl = item.ImageUrl,
                    Description = item.Description

                });
            }
            return dto;

        }

        public async Task UpdateAsync(Campaigns product, string companyId)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
            _queryRepository.SetDbContextInstance(_context);
            _companyDbUnitOfWork.SetDbContextInstance(_context);
            _commandRepository.Update(product);
            await _companyDbUnitOfWork.SaveChangesAsync();
        }
    }
}
