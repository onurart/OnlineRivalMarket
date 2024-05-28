using EntityFrameworkCorePagination.Nuget.Pagination;
using OnlineRivalMarket.Application.Features.CompanyFeatures.CampaignFeaures.Queries.GetAllDtoAsync;
using OnlineRivalMarket.Application.Services.CompanyServices;
using OnlineRivalMarket.Domain;
using OnlineRivalMarket.Domain.Dtos;
using OnlineRivalMarket.Domain.Dtos.Campaing;
using OnlineRivalMarket.Domain.Dtos.IntelligenceDto;
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
        _queryRepository.SetDbContextInstance(_context);
        int maxRowNo = await _queryRepository.GetAll(false).MaxAsync(x => (int?)x.RowNo ?? 0);
        Campaigns campaigns = _mapper.Map<Campaigns>(request);
        campaigns.Id = Guid.NewGuid().ToString();
        campaigns.RowNo = maxRowNo + 1;
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
                              CompetitorName = pc.Competitor != null ? pc.Competitor.Name : null,
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
                              ImageFiles = pc.CampaingImagesFiles.Select(x => x.CampaingFİleUrls),
                              RowNo = pc.RowNo,
                          }).ToList();

        List<CampaignsDetailDto> dto = new();
        foreach (var item in joinedData)
        {
            dto.Add(new CampaignsDetailDto()
            {
                Id = item.Id,
                CompetitorId = item.CompetitorId,
                CompetitorName = item.CompetitorName,
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
                CreateDate = item.CreateDate,
                UserLastName = item.UserLastName,
                UserId = item.UserId,
                RowNo = item.RowNo,


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
                              CompetitorName = pc.Competitor != null ? pc.Competitor.Name : null,
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
                              UserId = pc.UserId,
                              RowNo = (int)pc.RowNo
                          }).ToList();

        List<HomeTopCampaignDto> dto = new();
        foreach (var item in joinedData)
        {
            dto.Add(new HomeTopCampaignDto()
            {
                Id = item.Id,
                CompetitorId = item.CompetitorId,
                CompetitorName = item.CompetitorName,
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
                RowNo = item.RowNo
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
                              CompetitorName = pc.Competitor != null ? pc.Competitor.Name : null,
                              BrandId = p.BrandId,
                              BrandName = p.Brand.Name,
                              CategoryId = p.CategoryId,
                              CategoryName = p.Category.Name,
                              ProductId = p.Id,
                              ProductName = p.ProductName,
                              RowNo = (int)pc.RowNo,
                              Description = pc.Description,
                              EndTime = pc.EndTime,
                              StartTime = pc.StartTime,
                              ImageFiles = pc.CampaingImagesFiles.Select(x => x.CampaingFİleUrls),
                              UserLastName = pc.UserLastName,
                              UserId = pc.UserId,
                              CreateDate = pc.CreatedDate,
                          }).Take(6).ToList();
        List<HomeTopCampaignDto> dto = new();
        foreach (var item in joinedData)
        {
            dto.Add(new HomeTopCampaignDto()
            {
                Id = item.Id,
                CompetitorId = item.CompetitorId,
                CompetitorName = item.CompetitorName,
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
                RowNo = item.RowNo,

            });
        }
        return dto;
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
            CompetitorName = pc.Competitor?.Name,
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
            CreateDate = pc.CreatedDate,
            RowNo = (int)pc.RowNo,
        }).ToList();
        List<HomeTopCampaignDto> xView = new List<HomeTopCampaignDto>();


        return new PaginationResult<HomeTopCampaignDto>(
            pageNumber: request.PageNumber,
            pageSize: request.PageSize,
            totalCount: totalCount,
            datas: dtoList
        );
    }
    public async Task<IList<CampaignsDetailDto>> GetAllDtoFilterAsync(string companyId, List<string> competitorIds, List<string> productIds, List<string> brandIds, List<string> categoryIds, DateTime startDate, DateTime endDate, DateTime CreateDate, DateTime EndCreateDate, string keyword)
    {
        var context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(context);
        _queryProductRepository.SetDbContextInstance(context);

        var campaignQuery = _queryRepository.GetAll(false)
            .Include(pc => pc.Competitor)
            .Include(pc => pc.CampaingImagesFiles)
            .Include(pc => pc.Product)
            .AsQueryable();

        var productQuery = _queryProductRepository.GetAll(false)
          .Include(p => p.VehicleType)
          .Include(p => p.VehicleGrup)
          .Include(p => p.Brand)
          .Include(p => p.Category)
          .AsQueryable();

        bool isOtherFiltersEmpty = !(competitorIds?.Any() == true) &&
                                   !(productIds?.Any() == true) &&
                                   !(brandIds?.Any() == true) &&
                                   !(categoryIds?.Any() == true) &&
                                   string.IsNullOrEmpty(keyword);

        if (startDate != default & endDate != default && isOtherFiltersEmpty)
        {
            campaignQuery = campaignQuery.Where(pc => pc.StartTime >= startDate && pc.EndTime <= endDate.AddDays(1));
        }
        if (CreateDate != default && EndCreateDate != default)
        {
            campaignQuery = campaignQuery.Where(pc => pc.CreatedDate >= CreateDate && pc.CreatedDate <= EndCreateDate.AddDays(1));
        }

        else
        {

            if (competitorIds?.Any() == true)
            {
                campaignQuery = campaignQuery.Where(pc => competitorIds.Contains(pc.CompetitorId));
            }

            if (productIds?.Any() == true)
            {
                campaignQuery = campaignQuery.Where(pc => productIds.Contains(pc.ProductId));
            }

            if (brandIds?.Any() == true)
            {
                campaignQuery = campaignQuery.Where(pc => pc.Product != null && brandIds.Contains(pc.Product.BrandId));
            }

            if (categoryIds?.Any() == true)
            {
                campaignQuery = campaignQuery.Where(pc => pc.Product != null && categoryIds.Contains(pc.Product.CategoryId));
            }

            if (startDate != default && endDate != default)
            {
                campaignQuery = campaignQuery.Where(pc => pc.StartTime >= startDate && pc.EndTime <= endDate.AddDays(1));
            }
            if (!string.IsNullOrEmpty(keyword))
            {
                campaignQuery = campaignQuery.Where(pc =>
                    (pc.Description != null && pc.Description.Contains(keyword)) ||
                    (pc.Product.ProductName != null && pc.Product.ProductName.Contains(keyword)) ||
                    (pc.Product.Brand.Name != null && pc.Product.Brand.Name.Contains(keyword)) ||
                    (pc.Product.VehicleGrup != null && pc.Product.VehicleGrup.Name.Contains(keyword)) ||
                    (pc.Product.VehicleType != null && pc.Product.VehicleType.Name.Contains(keyword)) ||
                    (pc.Product.Category.Name != null && pc.Product.Category.Name.Contains(keyword))
                );
            }
        }

        var campaignList = await campaignQuery.ToListAsync();

        var joinedData = campaignList.Select(pc => new CampaignsDetailDto
        {
            Id = pc.Id,
            CompetitorId = pc.CompetitorId,
            CompetitorName = pc.Competitor?.Name,
            BrandId = pc.Product?.BrandId,
            BrandName = pc.Product?.Brand?.Name,
            CategoryId = pc.Product?.CategoryId,
            CategoryName = pc.Product?.Category?.Name,
            ProductId = pc.Product?.Id,
            ProductName = pc.Product?.ProductName,
            Description = pc.Description,
            ImageFiles = pc.CampaingImagesFiles.Select(x => x.CampaingFİleUrls),
            UserId = pc.UserId,
            UserLastName = pc.UserLastName,
            CreateDate = pc.CreatedDate,
            StartTime = pc.StartTime,
            EndTime = pc.EndTime,
            RowNo = pc.RowNo,
        }).ToList();

        return joinedData;
    }
    public async Task<IList<GetByCampaingProductIntelligenceRecord>> GetByCampaingProductIntelligenceRecordsAsync(string id, string companyId)
    {
        var context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(context);
        var campaigns = await _queryRepository.GetWhere(x => x.Product.Id == id, false)
            .Include(x => x.Product.VehicleGrup)
            .Include(x => x.Product.VehicleType)
            .Include(x => x.Product.Category)
            .Include(x => x.Product.Brand)
            .Include(x => x.Competitor)
            .Include(x => x.Product)
            .ToListAsync();
        var dtoList = campaigns.Select(pc => new GetByCampaingProductIntelligenceRecord
        {
            Id = pc.Id,
            CompetitorId = pc.CompetitorId,
            CompetitorName = pc.Competitor?.Name,
            BrandId = pc.Product?.BrandId,
            BrandName = pc.Product?.Brand?.Name,
            CategoryId = pc.Product?.CategoryId,
            CategoryName = pc.Product?.Category?.Name,
            ProductId = pc.Product?.Id,
            ProductName = pc.Product?.ProductName,
            Description = pc.Description,
            VehicleGroupId = pc.Product?.VehicleGrup?.Id,
            VehicleGroupName = pc.Product?.VehicleGrup?.Name,
            VehicleTypeId = pc.Product?.VehicleType?.Id,
            VehicleTypeName = pc.Product?.VehicleType?.Name,
            RowNo = pc.RowNo,
            EndTime = pc.EndTime,
            StartTime = pc.StartTime,
            CreateDate = pc.CreatedDate,
        }).ToList();

        return dtoList;
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

//public async Task<IList<CampaignsDetailDto>> GetAllDtoFilterAsync(string companyId, List<string> competitorIds, List<string> productIds, List<string> brandIds, List<string> categoryIds, DateTime startDate, DateTime endDate,  string keyword)
//{
//    throw new NotImplementedException();
//}
//public async Task<IList<CampaignsDetailDto>> GetAllDtoFilterAsync(string companyId, List<string> competitorIds, List<string> productIds, List<string> brandIds, List<string> categoryIds, DateTime startDate, DateTime endDate, DateTime CreateDate, DateTime EndCreateDate, string keyword)
//{
//    var context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
//    _queryRepository.SetDbContextInstance(context);
//    _queryProductRepository.SetDbContextInstance(context);
//    var campaignQuery = _queryRepository.GetAll(false)
//        .Include(pc => pc.Competitor)
//        .Include(pc => pc.CampaingImagesFiles)
//        .Include(pc => pc.Product)
//            .ThenInclude(p => p.Brand)
//        .Include(pc => pc.Product)
//            .ThenInclude(p => p.Category)
//        .AsQueryable();
//    var productQuery = _queryProductRepository.GetAll(false)
//      .Include(p => p.VehicleType)
//      .Include(p => p.VehicleGrup)
//      .Include(p => p.Brand)
//      .Include(p => p.Category)
//      .AsQueryable();
//    bool isOtherFiltersEmpty = !(competitorIds?.Any() == true) &&
//                       !(productIds?.Any() == true) &&
//                       !(brandIds?.Any() == true) &&
//                       !(categoryIds?.Any() == true) &&
//                       string.IsNullOrEmpty(keyword);

//    if (isOtherFiltersEmpty)
//    {
//        if (startDate != default && endDate != default)
//        {
//            campaignQuery = campaignQuery.Where(pc => pc.StartTime >= startDate && pc.EndTime <= endDate.AddDays(1));
//        }
//        if (CreateDate != default && EndCreateDate != default)
//        {
//            campaignQuery = campaignQuery.Where(pc => pc.CreatedDate >= CreateDate && pc.CreatedDate <= EndCreateDate.AddDays(1));
//        }
//    }
//    else
//    {
//        if (competitorIds?.Any() == true)
//        {
//            campaignQuery = campaignQuery.Where(pc => competitorIds.Contains(pc.CompetitorId));
//        }

//        if (productIds?.Any() == true)
//        {
//            campaignQuery = campaignQuery.Where(pc => productIds.Contains(pc.ProductId));
//        }

//        if (brandIds?.Any() == true)
//        {
//            campaignQuery = campaignQuery.Where(pc => pc.Product != null && brandIds.Contains(pc.Product.BrandId));
//        }

//        if (categoryIds?.Any() == true)
//        {
//            campaignQuery = campaignQuery.Where(pc => pc.Product != null && categoryIds.Contains(pc.Product.CategoryId));
//        }

//        if (startDate != default && endDate != default)
//        {
//            campaignQuery = campaignQuery.Where(pc => pc.StartTime >= startDate && pc.EndTime <= endDate.AddDays(1));
//        }

//        if (CreateDate != default && EndCreateDate != default)
//        {
//            campaignQuery = campaignQuery.Where(pc => pc.CreatedDate >= CreateDate && pc.CreatedDate <= EndCreateDate.AddDays(1));
//        }
//        if (!string.IsNullOrEmpty(keyword))
//        {
//            campaignQuery = campaignQuery.Where(pc =>
//                (pc.Description != null && pc.Description.Contains(keyword)) ||
//                (pc.Product.ProductName != null && pc.Product.ProductName.Contains(keyword)) ||
//                (pc.Product.Brand.Name != null && pc.Product.Brand.Name.Contains(keyword)) ||
//                (pc.Product.VehicleGrup != null && pc.Product.VehicleGrup.Name.Contains(keyword)) ||
//                (pc.Product.VehicleType != null && pc.Product.VehicleType.Name.Contains(keyword)) ||
//                (pc.Product.Category.Name != null && pc.Product.Category.Name.Contains(keyword))
//            );
//        }
//    }
//    var campaignList = await campaignQuery.ToListAsync();

//    var joinedData = campaignList.Select(pc => new CampaignsDetailDto
//    {
//        Id = pc.Id,
//        CompetitorId = pc.CompetitorId,
//        CompetitorsesName = pc.Competitor?.Name,
//        BrandId = pc.Product?.BrandId,
//        BrandName = pc.Product?.Brand?.Name,
//        CategoryId = pc.Product?.CategoryId,
//        CategoryName = pc.Product?.Category?.Name,
//        ProductId = pc.Product?.Id,
//        ProductName = pc.Product?.ProductName,
//        Description = pc.Description,
//        ImageFiles = pc.CampaingImagesFiles.Select(x => x.CampaingFİleUrls),
//        UserId = pc.UserId,
//        UserLastName = pc.UserLastName,
//        CreateDate = pc.CreatedDate,
//        StartTime = pc.StartTime,
//        EndTime = pc.EndTime,
//        RowNo = pc.RowNo
//    }).ToList();

//    return joinedData;
//}