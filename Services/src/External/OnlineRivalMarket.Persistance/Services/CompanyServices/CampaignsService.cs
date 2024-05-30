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
    public async Task<IList<GetAllDtoFilterDto>> GetAllDtoFilterAsync(string companyId, List<string> competitorIds, List<string> productIds, List<string> brandIds, List<string> categoryIds, DateTime startDate, DateTime endDate, DateTime CreateDate, DateTime EndCreateDate, string keyword)
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

        if (startDate != default && endDate != default && isOtherFiltersEmpty)
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

        var joinedData = campaignList.Select(pc => new GetAllDtoFilterDto
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
    public async Task<PaginationResult<HomeTopCampaignDto>> GetAllDtoAsync(GetAllDtoAsyncQuery request)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _queryRepository.SetDbContextInstance(_context);
        _queryProductRepository.SetDbContextInstance(_context);

        var baseQuery = _queryRepository.GetAll(false)
            .Include(x => x.Competitor)
            .Include(x => x.Product)
                .ThenInclude(p => p.Brand)
            .Include(x => x.Product)
                .ThenInclude(p => p.Category)
            .Include(x => x.CampaingImagesFiles)
            .OrderByDescending(x => x.CreatedDate);

        var result = await baseQuery.ToPagedListAsync(request.PageSize, request.PageNumber);
        int count = _queryRepository.GetAll().Count();
                var dtoList = result.Datas.Select(pc => new HomeTopCampaignDto
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
            RowNo = (int)pc.RowNo
        }).ToList();
        return new PaginationResult<HomeTopCampaignDto>(
            pageNumber: request.PageNumber,
            pageSize: request.PageSize,
            totalCount: count,
            datas: dtoList
        );
    }
    public async Task<IList<CampaignsDetailDto>> GetListByIdDtoAsync(string id, string companyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);
        _queryProductRepository.SetDbContextInstance(_context);

        var prodcustrel = await _queryRepository.GetWhere(x => x.Id == id, false)
            .Include(x => x.Competitor)
            .Include(x => x.Product)
            .Include(x => x.CampaingImagesFiles)
            .ToListAsync();

        var product = await _queryProductRepository.GetAll()
            .Include(x => x.Category)
            .Include(x => x.Brand)
            .ToListAsync();

        var joinedData = (from pc in prodcustrel
                          join p in product on pc.ProductId equals p.Id
                          orderby pc.CreatedDate descending
                          select new CampaignsDetailDto
                          {
                              Id = pc.Id,
                              CompetitorId = pc.CompetitorId,
                              CompetitorName = pc.Competitor?.Name,
                              BrandId = p.BrandId,
                              BrandName = p.Brand?.Name,
                              CategoryId = p.CategoryId,
                              CategoryName = p.Category?.Name,
                              ProductId = p.Id,
                              ProductName = p.ProductName,
                              Description = pc.Description,
                              EndTime = pc.EndTime,
                              StartTime = pc.StartTime,
                              CreateDate = pc.CreatedDate,
                              UserLastName = pc.UserLastName,
                              UserId = pc.UserId,
                              ImageFiles = pc.CampaingImagesFiles.Select(x => x.CampaingFİleUrls),
                              RowNo = pc.RowNo
                          }).ToList();

        return joinedData;
    }
    public async Task<IList<HomeTopCampaignDto>> HomeTopGetAllDtoAsync(string companyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);
        _queryProductRepository.SetDbContextInstance(_context);

        var prodcustrel = await _queryRepository.GetAll()
            .Include(pc => pc.Competitor)
            .Include(pc => pc.Product)
            .Include(pc => pc.CampaingImagesFiles)
            .ToListAsync();
        var product = await _queryProductRepository.GetAll()
            .Include(p => p.Category)
            .Include(p => p.Brand)
            .ToListAsync();
        var joinedData = (from pc in prodcustrel
                          join p in product on pc.ProductId equals p.Id
                          orderby pc.CreatedDate descending
                          select new HomeTopCampaignDto
                          {
                              Id = pc.Id,
                              CompetitorId = pc.CompetitorId,
                              CompetitorName = pc.Competitor?.Name,
                              BrandId = p.BrandId,
                              BrandName = p.Brand?.Name,
                              CategoryId = p.CategoryId,
                              CategoryName = p.Category?.Name,
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

        return joinedData;
    }
    public async Task<IList<GetAllCampaingDto>> GetAllCampaingAsync(string companyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);
        _queryProductRepository.SetDbContextInstance(_context);
        var prodcustrel = await _queryRepository.GetAll()
            .Include(x => x.Competitor)
            .Include(x => x.Product)
            .Include(x => x.CampaingImagesFiles)
            .ToListAsync();
        var product = await _queryProductRepository.GetAll()
            .Include(x => x.Category)
            .Include(x => x.Brand)
            .ToListAsync();
        var joinedData = (from pc in prodcustrel
                          join p in product on pc.ProductId equals p.Id
                          orderby pc.CreatedDate descending
                          select new GetAllCampaingDto
                          {
                              Id = pc.Id,
                              CompetitorId = pc.CompetitorId,
                              CompetitorName = pc.Competitor?.Name,
                              BrandId = p.BrandId,
                              BrandName = p.Brand.Name,
                              CategoryId = p.CategoryId,
                              CategoryName = p.Category.Name,
                              ProductId = p.Id,
                              ProductName = p.ProductName,
                              Description = pc.Description,
                              StartTime = pc.StartTime,
                              EndTime = pc.EndTime,
                              ImageFiles = pc.CampaingImagesFiles?.Select(x => x.CampaingFİleUrls),
                              CreateDate = pc.CreatedDate,
                              UserLastName = pc.UserLastName,
                              UserId = pc.UserId,
                              RowNo = (int)pc.RowNo
                          }).ToList();

        return joinedData;
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

