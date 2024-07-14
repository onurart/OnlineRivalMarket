namespace OnlineRivalMarket.Persistance.Services.CompanyServices;
public class IntelligenceRecordService : IIntelligenceRecordService
{
    private readonly IIntelligenceRecordCommandRepository _commandRepository;
    private readonly IIntelligenceRecordQueryRepository _queryRepository;
    private readonly IProductQueryRepository _queryProductRepository;
    private readonly ICompanyDbUnitOfWork _unitOfWork;
    private readonly IContextService _contextService;
    private readonly IMapper _mapper;
    private CompanyDbContext _context;
    public IntelligenceRecordService(IIntelligenceRecordCommandRepository commandRepository, IIntelligenceRecordQueryRepository queryRepository, ICompanyDbUnitOfWork unitOfWork, IContextService contextService, IMapper mapper, IProductQueryRepository queryProductRepository = null)
    {
        _commandRepository = commandRepository;
        _queryRepository = queryRepository;
        _unitOfWork = unitOfWork;
        _contextService = contextService;
        _mapper = mapper;
        _queryProductRepository = queryProductRepository;
    }
    public async Task<PaginationResult<IntelligenceRecordDto>> GetAllIIntelligenceDtoFilterAsync
        (string companyId,
        List<string> competitorIds,
        List<string> vehiclegroup,
        List<string> categoryIds,
        List<string> vehicleype,
        List<string> productIds,
        List<string> brandIds,
        DateTime startDate,
        DateTime endDate,
        string keyword, int pageNumber,
       int pageSize)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);
        _queryProductRepository.SetDbContextInstance(_context);

        var query = _queryRepository
            .GetAll(false)
            .Include(pc => pc.Competitor)
            .Include(pc => pc.IntelligenceRecordFiles)
            .Include(pc => pc.Product)
            .Include(pc => pc.ForeignCurrency).Include(x => x.Product.VehicleGrup).Include(x => x.Product.VehicleType)
            .Where(pc =>
                (startDate == default || pc.CreatedDate >= startDate) &&
                (endDate == default || pc.CreatedDate <= endDate.AddDays(1)) &&
                (competitorIds == null || !competitorIds.Any() || competitorIds.Contains(pc.CompetitorId)) &&
                (productIds == null || !productIds.Any() || productIds.Contains(pc.ProductId)) &&
                (brandIds == null || !brandIds.Any() || (pc.Product != null && brandIds.Contains(pc.Product.BrandId))) &&
                (categoryIds == null || !categoryIds.Any() || (pc.Product != null && categoryIds.Contains(pc.Product.CategoryId))) &&
                (vehiclegroup == null || !vehiclegroup.Any() || (pc.Product != null && vehiclegroup.Contains(pc.Product.VehicleGrup.Id))) &&
                (vehicleype == null || !vehicleype.Any() || (pc.Product != null && vehicleype.Contains(pc.Product.VehicleType.Id))) &&
                (string.IsNullOrEmpty(keyword) ||
                    (pc.Description != null && pc.Description.Contains(keyword)) ||
                    (pc.Product.ProductName != null && pc.Product.ProductName.Contains(keyword)) ||
                    (pc.Product.Brand.Name != null && pc.Product.Brand.Name.Contains(keyword)) ||
                    (pc.Product.VehicleGrup != null && pc.Product.VehicleGrup.Name.Contains(keyword)) ||
                    (pc.Product.VehicleType != null && pc.Product.VehicleType.Name.Contains(keyword)) ||
                    (pc.Product.Category.Name != null && pc.Product.Category.Name.Contains(keyword)))
            );
        var totalCount = await query.CountAsync();

        var result = await query.OrderByDescending(pc => pc.CreatedDate).ToListAsync();

        var joinedData = result.Select(pc => new IntelligenceRecordDto
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
            VehicleGroupId = pc.Product?.VehicleGrup?.Id,
            VehicleGroupName = pc.Product?.VehicleGrup?.Name,
            VehicleTypeId = pc.Product?.VehicleType?.Id,
            VehicleTypeName = pc.Product?.VehicleType?.Name,
            Description = pc.Description,
            MCurrency = pc.MCurrency,
            RakipCurrency = pc.RakipCurrency,
            ForeignCurrencyId = pc.ForeignCurrencyId,
            ForeignCurrencyName = pc.ForeignCurrency?.CurrencyName,
            ImageFiles = pc.IntelligenceRecordFiles.Select(x => x.FileUrls),
            CreatedDate = pc.CreatedDate,
            UserId = pc.UserId,
            UserLastName = pc.UserLastName,
            RowNo = (int)pc.RowNo,
        }).ToList();

        return new PaginationResult<IntelligenceRecordDto>(joinedData, totalCount, pageNumber, pageSize);
    }
    public async Task<IntelligenceRecord> CreateIntelligenceRecordAsync(CreateIntelligenceRecordCommand requset, CancellationToken cancellationToken)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(requset.CompanyId);
        _queryRepository.SetDbContextInstance(_context);
        _commandRepository.SetDbContextInstance(_context);
        _unitOfWork.SetDbContextInstance(_context);
        int maxRowNo = await _queryRepository.GetAll(false).MaxAsync(x => (int?)x.RowNo ?? 0);
        IntelligenceRecord record = _mapper.Map<IntelligenceRecord>(requset);
        record.Id = Guid.NewGuid().ToString();
        record.RowNo = maxRowNo + 1;
        await _commandRepository.AddAsync(record, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return record;
    }
    public async Task<IList<IntelligenceByIdDto>> GetByProductIdIntelligenceRecordsAsync(string id, string companyId)
    {
        var context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(context);

        var intelligenceRecords = await _queryRepository.GetWhere(x => x.Product.Id == id, false)
            .Include(x => x.IntelligenceRecordFiles)
            .Include(x => x.Product.VehicleGrup)
            .Include(x => x.Product.VehicleType)
            .Include(x => x.ForeignCurrency)
            .Include(x => x.Product.Category)
            .Include(x => x.Product.Brand)
            .Include(x => x.Competitor)
            .Include(x => x.Product)
            .ToListAsync();

        var dtoList = intelligenceRecords.Select(pc => new IntelligenceByIdDto
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
            MCurrency = pc.MCurrency,
            RakipCurrency = pc.RakipCurrency,
            ForeignCurrencyId = pc.ForeignCurrencyId,
            ForeignCurrencyName = pc.ForeignCurrency?.CurrencyName,
            ImageFiles = pc.IntelligenceRecordFiles.Select(x => x.FileUrls),
            CreateDate = pc.CreatedDate,
            UserId = pc.UserId,
            UserLastName = pc.UserLastName,
            RowNo = pc.RowNo,
        }).ToList();

        return dtoList;
    }
    public async Task<IList<IntelligenceByIdDto>> GetByIdIntelligenceRecordsAsync(string id, string companyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);
        _queryProductRepository.SetDbContextInstance(_context);

        var intelligence = await _queryRepository
            .GetWhere(x => x.Id == id, false)
            .Include(x => x.Competitor)
            .Include(x => x.IntelligenceRecordFiles)
            .Include(x => x.Product)
            .Include(x => x.ForeignCurrency)
            .ToListAsync();

        var product = await _queryProductRepository
            .GetAll()
            .Include(x => x.VehicleType)
            .Include(x => x.VehicleGrup)
            .Include(x => x.Brand)
            .Include(x => x.Category)
            .ToListAsync();

        var joinedData = (from pc in intelligence
                          join p in product on pc.ProductId equals p.Id
                          orderby pc.CreatedDate descending
                          select new IntelligenceByIdDto
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
                              VehicleGroupId = p.VehicleGrup.Id,
                              VehicleGroupName = p.VehicleGrup.Name,
                              VehicleTypeId = p.VehicleType.Id,
                              VehicleTypeName = p.VehicleType.Name,
                              MCurrency = pc.MCurrency,
                              RakipCurrency = pc.RakipCurrency,
                              ForeignCurrencyId = pc.ForeignCurrencyId,
                              ForeignCurrencyName = pc.ForeignCurrency?.CurrencyName,
                              ImageFiles = pc.IntelligenceRecordFiles?.Select(x => x.FileUrls),
                              CreateDate = pc.CreatedDate,
                              UserId = pc.UserId,
                              UserLastName = pc.UserLastName,
                              RowNo = pc.RowNo
                          })
                          .Take(5)
                          .ToList();

        return joinedData;
    }
    public async Task<IList<IntelligenceRecordDto>> HomeGetTopIntelligenceRecordAsync(string companyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);
        _queryProductRepository.SetDbContextInstance(_context);

        var prodcustrel = await _queryRepository.GetAll()
            .Include(x => x.Competitor)
            .Include(x => x.Product)
            .Include(x => x.ForeignCurrency)
            .Include(x => x.IntelligenceRecordFiles)
            .ToListAsync();

        var product = await _queryProductRepository.GetAll()
            .Include(x => x.VehicleType)
            .Include(x => x.VehicleGrup)
            .Include(x => x.Brand)
            .Include(x => x.Category)
            .ToListAsync();

        var joinedData = (from pc in prodcustrel
                          join p in product on pc.ProductId equals p.Id
                          orderby pc.CreatedDate descending
                          select new IntelligenceRecordDto
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
                              MCurrency = pc.MCurrency,
                              RakipCurrency = pc.RakipCurrency,
                              ForeignCurrencyName = pc.ForeignCurrency?.CurrencyName,
                              ForeignCurrencyId = pc.ForeignCurrency?.Id,
                              VehicleGroupId = p.VehicleGrup?.Id,
                              VehicleGroupName = pc.Product.VehicleGrup?.Name,
                              VehicleTypeId = pc.Product.VehicleType?.Id,
                              VehicleTypeName = pc.Product.VehicleType?.Name,
                              ImageFiles = pc.IntelligenceRecordFiles?.Select(x => x.FileUrls),
                              CreatedDate = pc.CreatedDate,
                              UserLastName = pc.UserLastName,
                              UserId = pc.UserId,
                          })
                          .Take(12)
                          .ToList();

        return joinedData;
    }
    public async Task<IList<IntelligenceRecordDto>> GetAllDtoAsync(string companyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);
        _queryProductRepository.SetDbContextInstance(_context);

        var prodcustrel = await _queryRepository.GetAll()
            .Include(x => x.Competitor)
            .Include(x => x.IntelligenceRecordFiles)
            .Include(x => x.Product)
            .Include(x => x.ForeignCurrency)
            .ToListAsync();

        var product = await _queryProductRepository.GetAll()
            .Include(x => x.VehicleType)
            .Include(x => x.VehicleGrup)
            .Include(x => x.Brand)
            .Include(x => x.Category)
            .ToListAsync();

        var joinedData = from pc in prodcustrel
                         join p in product on pc.ProductId equals p.Id
                         orderby pc.CreatedDate descending
                         select new IntelligenceRecordDto
                         {
                             Id = pc.Id,
                             CompetitorId = pc.CompetitorId,
                             CompetitorName = pc.Competitor?.Name,
                             BrandId = p.Brand?.Id,
                             BrandName = p.Brand?.Name,
                             CategoryId = p.Category?.Id,
                             CategoryName = p.Category?.Name,
                             ProductId = p.Id,
                             ProductName = p.ProductName,
                             VehicleGroupId = p.VehicleGrup?.Id,
                             VehicleGroupName = pc.Product?.VehicleGrup?.Name,
                             VehicleTypeId = pc.Product?.VehicleType?.Id,
                             VehicleTypeName = pc.Product?.VehicleType?.Name,
                             Description = pc.Description,
                             MCurrency = pc.MCurrency,
                             RakipCurrency = pc.RakipCurrency,
                             ForeignCurrencyId = pc.ForeignCurrencyId,
                             ForeignCurrencyName = pc.ForeignCurrency?.CurrencyName,
                             ImageFiles = pc.IntelligenceRecordFiles?.Select(x => x.FileUrls),
                             CreatedDate = pc.CreatedDate,
                             UserId = pc.UserId,
                             UserLastName = pc.UserLastName,
                             RowNo = pc.RowNo
                         };

        return joinedData.ToList();
    }

    //public async Task<IList<IntelligenceRecordDto>> GetAllIIntelligenceDtoFilterAsync(string companyId, List<string> competitorIds, List<string> productIds, List<string> brandIds, List<string> categoryIds, List<string> vehiclegroup, List<string> vehicleype, DateTime startDate, DateTime endDate, string keyword)
    //{
    //    _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
    //    _queryRepository.SetDbContextInstance(_context);
    //    _queryProductRepository.SetDbContextInstance(_context);

    //    var query = _queryRepository
    //        .GetAll(false)
    //        .Include(pc => pc.Competitor)
    //        .Include(pc => pc.IntelligenceRecordFiles)
    //        .Include(pc => pc.Product)
    //        .Include(pc => pc.ForeignCurrency).Include(x => x.Product.VehicleGrup).Include(x => x.Product.VehicleType)
    //        .Where(pc =>
    //            (startDate == default || pc.CreatedDate >= startDate) &&
    //            (endDate == default || pc.CreatedDate <= endDate.AddDays(1)) &&
    //            (competitorIds == null || !competitorIds.Any() || competitorIds.Contains(pc.CompetitorId)) &&
    //            (productIds == null || !productIds.Any() || productIds.Contains(pc.ProductId)) &&
    //            (brandIds == null || !brandIds.Any() || (pc.Product != null && brandIds.Contains(pc.Product.BrandId))) &&
    //            (categoryIds == null || !categoryIds.Any() || (pc.Product != null && categoryIds.Contains(pc.Product.CategoryId))) &&
    //            (vehiclegroup == null || !vehiclegroup.Any() || (pc.Product != null && vehiclegroup.Contains(pc.Product.VehicleGrup.Id))) &&
    //            (vehicleype == null || !vehicleype.Any() || (pc.Product != null && vehicleype.Contains(pc.Product.VehicleType.Id))) &&
    //            (string.IsNullOrEmpty(keyword) ||
    //                (pc.Description != null && pc.Description.Contains(keyword)) ||
    //                (pc.Product.ProductName != null && pc.Product.ProductName.Contains(keyword)) ||
    //                (pc.Product.Brand.Name != null && pc.Product.Brand.Name.Contains(keyword)) ||
    //                (pc.Product.VehicleGrup != null && pc.Product.VehicleGrup.Name.Contains(keyword)) ||
    //                (pc.Product.VehicleType != null && pc.Product.VehicleType.Name.Contains(keyword)) ||
    //                (pc.Product.Category.Name != null && pc.Product.Category.Name.Contains(keyword)))
    //        );

    //    var result = await query.OrderByDescending(pc => pc.CreatedDate).ToListAsync();

    //    var joinedData = result.Select(pc => new IntelligenceRecordDto
    //    {
    //        Id = pc.Id,
    //        CompetitorId = pc.CompetitorId,
    //        CompetitorName = pc.Competitor?.Name,
    //        BrandId = pc.Product?.BrandId,
    //        BrandName = pc.Product?.Brand?.Name,
    //        CategoryId = pc.Product?.CategoryId,
    //        CategoryName = pc.Product?.Category?.Name,
    //        ProductId = pc.Product?.Id,
    //        ProductName = pc.Product?.ProductName,
    //        VehicleGroupId = pc.Product?.VehicleGrup?.Id,
    //        VehicleGroupName = pc.Product?.VehicleGrup?.Name,
    //        VehicleTypeId = pc.Product?.VehicleType?.Id,
    //        VehicleTypeName = pc.Product?.VehicleType?.Name,
    //        Description = pc.Description,
    //        MCurrency = pc.MCurrency,
    //        RakipCurrency = pc.RakipCurrency,
    //        ForeignCurrencyId = pc.ForeignCurrencyId,
    //        ForeignCurrencyName = pc.ForeignCurrency?.CurrencyName,
    //        ImageFiles = pc.IntelligenceRecordFiles.Select(x => x.FileUrls),
    //        CreatedDate = pc.CreatedDate,
    //        UserId = pc.UserId,
    //        UserLastName = pc.UserLastName,
    //        RowNo = (int)pc.RowNo,
    //    }).ToList();

    //    return joinedData;
    //}

}
