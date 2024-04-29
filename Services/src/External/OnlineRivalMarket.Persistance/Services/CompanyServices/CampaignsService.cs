using AutoMapper;
using EntityFrameworkCorePagination.Nuget.Pagination;
using Microsoft.EntityFrameworkCore;
using OnlineRivalMarket.Application.Features.CompanyFeatures.CampaignFeaures.Commands.CreateCampaign;
using OnlineRivalMarket.Application.Features.CompanyFeatures.CampaignFeaures.Queries;
using OnlineRivalMarket.Application.Features.CompanyFeatures.CampaignFeaures.Queries.GetAllDtoAsync;
using OnlineRivalMarket.Application.Services.CompanyServices;
using OnlineRivalMarket.Domain;
using OnlineRivalMarket.Domain.CompanyEntities;
using OnlineRivalMarket.Domain.Dtos;
using OnlineRivalMarket.Domain.Dtos.HomeTopDto;
using OnlineRivalMarket.Domain.Repositories.CompanyDbContext.CampaignRepository;
using OnlineRivalMarket.Domain.Repositories.CompanyDbContext.ProductRepositories;
using OnlineRivalMarket.Domain.UnitOfWorks;
using OnlineRivalMarket.Persistance.Context;
namespace OnlineRivalMarket.Persistance.Services.CompanyServices;
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
    //public async Task<PaginationResult<Campaigns>> GetAllAsync(GetAllCampaignQuery request)
    //{
    //    _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
    //    _queryRepository.SetDbContextInstance(_context);
    //    PaginationResult<Campaigns> result = await _queryRepository.GetAll(false).ToPagedListAsync(request.PageNumber, request.PageSize);

    //    int count = _queryRepository.GetAll().Count();
    //    IList<Campaigns> list = new List<Campaigns>();
    //    if (result.Datas != null)
    //    {
    //        foreach (var data in result.Datas)
    //        {
    //            Campaigns campaigns = new Campaigns()
    //            {
    //                Id = data.Id,
    //                CompetitorId = data.CompetitorId,
    //                Competitor = data.Competitor.name,
    //                CreatedDate = data.CreatedDate,
    //                Description = data.Description,
    //                EndTime = data.EndTime,
    //                ImageUrl = data.ImageUrl,
    //                ProductId = data.ProductId,
    //                StartTime = data.StartTime,
    //                IsActive = data.IsActive,
    //                Product = data.Product,
    //            };
    //            list.Add(campaigns);
    //        }
    //    }
    //    PaginationResult<Campaigns> paginationResult = new(
    //        pageNumber: result.PageNumber,
    //        pageSize: result.PageSize,
    //        totalCount: count,
    //        datas: list
    //        );
    //    return paginationResult;
    //}
    public async Task<PaginationResult<HomeTopCampaignDto>> GetAllDtoAsync(GetAllDtoAsyncQuery request)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _queryRepository.SetDbContextInstance(_context);
        _queryProductRepository.SetDbContextInstance(_context);
        PaginationResult<Campaigns> result = await _queryRepository.GetAll(false).ToPagedListAsync(request.PageNumber, request.PageSize);

        int count = _queryRepository.GetAll().Count();
        IList<HomeTopCampaignDto> list = new List<HomeTopCampaignDto>();
        var prodcustrel = await _queryRepository.GetAll().Include("Competitor").Include("Product").ToListAsync();
        var product = await _queryProductRepository.GetAll().Include("Category").Include("Brand").ToListAsync();
        var joinedData = (from pc in prodcustrel
                          join p in product on pc.ProductId equals p.Id
                          orderby pc.CreatedDate descending
                          select new HomeTopCampaignDto
                          {
                              CompetitorId = pc.CompetitorId,
                              CompetitorsesName = pc.Competitor != null ? pc.Competitor.Name : null,
                              BrandId = p.BrandId,
                              BrandName = p.Brand.Name,
                              CategoryId = p.CategoryId,
                              CategoryName = p.Category.Name,
                              ProductId = p.Id,
                              ProductName = p.ProductName,
                              Description = pc.Description,
                              EndTime = pc.EndTime,
                              StartTime = pc.StartTime,

                              ImageUrl = pc.ImageUrl,
                          }).ToList();


        foreach (var item in joinedData)
        {
            list.Add(new HomeTopCampaignDto()
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
                Description = item.Description,
                StartTime = item.StartTime,
                EndTime = item.EndTime,


            });
        }
        PaginationResult<HomeTopCampaignDto> paginationResult = new(
                   pageNumber: result.PageNumber,
                   pageSize: result.PageSize,
                   totalCount: count,
                   datas: list
                   );
        return paginationResult;
    }
    public async Task<IList<CampaignsDetailDto>> GetListByIdDtoAsync(string id, string companyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);
        _queryProductRepository.SetDbContextInstance(_context);
        var prodcustrel = await _queryRepository.GetWhere(x => x.Id == id,false).Include("Competitor").Include("Product").ToListAsync();
        var product = await _queryProductRepository.GetAll().Include("Category").Include("Brand").ToListAsync();

        var joinedData = (from pc in prodcustrel
                          join p in product on pc.ProductId equals p.Id
                          orderby pc.CreatedDate descending
                          select new CampaignsDetailDto
                          {
                              Id = pc.Id,
                              CompetitorId = pc.CompetitorId,
                              CompetitorsesName = pc.Competitor != null ? pc.Competitor.Name : null,
                              BrandId = p.BrandId,
                              BrandName = p.Brand.Name,
                              CategoryId = p.CategoryId,
                              CategoryName = p.Category.Name,
                              ProductId = p.Id,
                              ProductName = p.ProductName,
                              Description = pc.Description,
                              EndTime = pc.EndTime,
                              StartTime = pc.StartTime,
                              ImageUrl = pc.ImageUrl,
                          }).ToList();

        List<CampaignsDetailDto> dto = new();
        foreach (var item in joinedData)
        {
            dto.Add(new CampaignsDetailDto()
            {
                Id = item.Id,
                CompetitorId = item.CompetitorId,
                CompetitorsesName = item.CompetitorsesName,
                BrandId = item.BrandId,
                BrandName = item.BrandName,
                CategoryId = item.CategoryId,
                CategoryName = item.CategoryName,
                ProductId = item.ProductId,
                ProductName = item.ProductName,
                ImageUrl = item.ImageUrl,
                Description = item.Description,
                StartTime = item.StartTime,
                EndTime = item.EndTime,


            });
        }
        return dto;
    }

    public async Task<IList<HomeTopCampaignDto>> HomeTopGetAllDtoAsync(string companyId)
    {
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
                              CompetitorsesName = pc.Competitor != null ? pc.Competitor.Name : null,
                              BrandId = p.BrandId,
                              BrandName = p.Brand.Name,
                              CategoryId = p.CategoryId,
                              CategoryName = p.Category.Name,
                              ProductId = p.Id,
                              ProductName = p.ProductName,
                              Description = pc.Description,
                              EndTime = pc.EndTime,
                              StartTime = pc.StartTime,

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
                Description = item.Description,
                StartTime = item.StartTime,
                EndTime = item.EndTime,


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
