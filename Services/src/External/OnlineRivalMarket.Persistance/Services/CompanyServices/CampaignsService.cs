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

    public async Task<IList<CampaignsDetailDto>> GetListByIdDtoAsync(string id, string companyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);
        _queryProductRepository.SetDbContextInstance(_context);
        var prodcustrel = await _queryRepository.GetWhere(x => x.Id == id, false).Include("Competitor").Include("Product").Include(x => x.CampaingImagesFiles).ToListAsync();
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
                              CreateDate = pc.CreatedDate,
                              UserLastName = pc.UserLastName,
                              UserId = pc.UserId,
                              ImageFiles = pc.CampaingImagesFiles.Select(x => x.CampaingFİleUrls)
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
                //ImageUrl = item.ImageUrl,
                Description = item.Description,
                StartTime = item.StartTime,
                EndTime = item.EndTime,
                ImageFiles = item.ImageFiles,
                CreateDate = item.CreateDate,
                UserLastName = item.UserLastName,
                UserId = item.UserId,


            });
        }
        return dto;
    }
    public async Task<IList<HomeTopCampaignDto>> GetAllCampaingAsync(string companyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);
        _queryProductRepository.SetDbContextInstance(_context);
        var prodcustrel = await _queryRepository.GetAll().Include("Competitor").Include("Product").Include(x => x.CampaingImagesFiles).ToListAsync();
        var product = await _queryProductRepository.GetAll().Include("Category").Include("Brand").ToListAsync();
        var joinedData = (from pc in prodcustrel
                          join p in product on pc.ProductId equals p.Id
                          orderby pc.CreatedDate descending
                          select new HomeTopCampaignDto
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
                              ImageFiles = pc.CampaingImagesFiles != null ? pc.CampaingImagesFiles.Select(x => x.CampaingFİleUrls) : null,
                              CreateDate = p.CreatedDate,
                              UserLastName = pc.UserLastName,
                              UserId = pc.UserId
                          }).ToList();

        List<HomeTopCampaignDto> dto = new();
        foreach (var item in joinedData)
        {
            dto.Add(new HomeTopCampaignDto()
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
                Description = item.Description,
                StartTime = item.StartTime,
                EndTime = item.EndTime,
                ImageFiles = item.ImageFiles,
                UserLastName = item.UserLastName,
                UserId = item.UserId,
                CreateDate = item.CreateDate,
            });
        }
        return dto;
    }
    public async Task<IList<HomeTopCampaignDto>> HomeTopGetAllDtoAsync(string companyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);
        _queryProductRepository.SetDbContextInstance(_context);
        var prodcustrel = await _queryRepository.GetAll().Include("Competitor").Include("Product").Include(x => x.CampaingImagesFiles).ToListAsync();
        var product = await _queryProductRepository.GetAll().Include("Category").Include("Brand").ToListAsync();
        var joinedData = (from pc in prodcustrel
                          join p in product on pc.ProductId equals p.Id
                          orderby pc.CreatedDate descending
                          select new HomeTopCampaignDto
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
                              ImageFiles = pc.CampaingImagesFiles.Select(x => x.CampaingFİleUrls),
                              UserLastName = pc.UserLastName,
                              UserId = pc.UserId
                          }).Take(6).ToList();
        List<HomeTopCampaignDto> dto = new();
        foreach (var item in joinedData)
        {
            dto.Add(new HomeTopCampaignDto()
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
                Description = item.Description,
                StartTime = item.StartTime,
                EndTime = item.EndTime,
                ImageFiles = item.ImageFiles,
                UserLastName = item.UserLastName,
                UserId = item.UserId,
                CreateDate = item.CreateDate

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

    public async Task<PaginationResult<HomeTopCampaignDto>> GetAllDtoAsync(GetAllDtoAsyncQuery request)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _queryRepository.SetDbContextInstance(_context);
        _queryProductRepository.SetDbContextInstance(_context);
        var baseQuery = _queryRepository.GetAll(false)
            .Include(x => x.Competitor)
            .Include(x => x.Product)
            .Include(x => x.CampaingImagesFiles)
            .OrderByDescending(x => x.CreatedDate);
        var pagedData = await baseQuery
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync();

        //PaginationResult<HomeTopCampaignDto> result = await _queryRepository.GetAll(false).OrderByDescending(p => p.CreatedDate).ToPagedListAsync(request.PageNumber, request.PageSize);

        int totalCount = await _queryRepository.GetAll().CountAsync();
        var dtoList = pagedData.Select(pc => new HomeTopCampaignDto
        {
            Id = pc.Id,
            CompetitorId = pc.CompetitorId,
            CompetitorsesName = pc.Competitor?.Name,
            BrandId = pc.Product?.BrandId,
            BrandName = pc.Product?.Brand?.Name,
            CategoryId = pc.Product?.CategoryId,
            CategoryName = pc.Product?.Category?.Name,
            ProductId = pc.Product?.Id,
            ProductName = pc.Product?.ProductName,
            Description = pc.Description,
            EndTime = pc.EndTime,
            StartTime = pc.StartTime,
            UserLastName = pc.UserLastName,
            UserId = pc.UserId,
            ImageFiles = pc.CampaingImagesFiles.Select(x => x.CampaingFİleUrls),
            CreateDate = pc.CreatedDate
        }).ToList();
        List<HomeTopCampaignDto> xView = new List<HomeTopCampaignDto>();
    

        return new PaginationResult<HomeTopCampaignDto>(
            pageNumber: request.PageNumber,
            pageSize: request.PageSize,
            totalCount: totalCount,
            datas: dtoList
        );
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
    //public Task<IList<Campaigns>> GetCampaignsAsync(string companyId)
    //{
    //    throw new NotImplementedException();
    //}
}
