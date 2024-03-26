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

        public async Task<IList<Campaigns>> HomeTopGetAllDtoAsync(string companyId)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
            _queryRepository.SetDbContextInstance(_context);
            return await _queryRepository.GetAll().AsNoTracking().OrderBy(c => c.CreatedDate).Take(5).ToListAsync();
            //_context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
            //_queryRepository.SetDbContextInstance(_context);

            //var result = await _queryRepository.GetAll()
            //    .Include(pc => pc.Competitors)
            //    .Include(pc => pc.Brand)
            //    .Include(pc => pc.Category)
            //    .Take(5)
            //    .ToListAsync();

            //var dto = result.Select(pc => new HomeTopCampaignDto
            //{
            //    CompetitorsId = pc.CompetitorsId,
            //    CompetitorName = pc.Competitors.Name,
            //    BrandId = pc.BrandId,
            //    BrandName = pc.Brand.Name,
            //    CategoryId = pc.CategoryId,
            //    CategoryName = pc.Category.Name,
            //    Description = pc.Description,
            //    ImageUrl = pc.ImageUrl
            //}).ToList();

            //List<HomeTopCampaignDto> dtoList = new();
            //foreach (var item in result)
            //{
            //    dtoList.Add(new HomeTopCampaignDto()
            //    {
            //        BrandId = item.BrandId,
            //        CompetitorName = item.Competitors.Name,
            //        CompetitorsId = item.CompetitorsId,
            //        CreatedDate = item.CreatedDate,
            //        Description = item.Description,
            //        ImageUrl = item.ImageUrl,
            //        StartTime = item.StartTime,
            //        EndTime = item.EndTime,
            //        BrandName = item.Brand.Name,
            //    });
            //}
            //dtoList.AddRange(dto); // dto'daki öğeleri dtoList'e ekleyin
            //return dtoList.OrderBy(x => x.CreatedDate).Take(5).ToList();
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
