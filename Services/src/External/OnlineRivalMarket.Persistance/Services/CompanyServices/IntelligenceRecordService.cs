using OnlineRivalMarket.Application.Services.CompanyServices;
using OnlineRivalMarket.Domain;
using OnlineRivalMarket.Domain.Dtos;
using OnlineRivalMarket.Domain.Dtos.IntelligenceDto;

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
    public async Task<IList<IntelligenceRecordDto>> GetAllDtoAsync(string companyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);
        _queryProductRepository.SetDbContextInstance(_context);
        var prodcustrel = await _queryRepository.GetAll().Include("Competitor").Include("IntelligenceRecordFiles")
            .Include("Product").Include("ForeignCurrency").ToListAsync();
        var product = await _queryProductRepository.GetAll().Include("VehicleType").Include("VehicleGrup")
            .Include("Brand").Include("Category").ToListAsync();

        var joinedData = from pc in prodcustrel
                         join p in product on pc.ProductId equals p.Id
                         orderby pc.CreatedDate descending
                         select new IntelligenceRecordDto
                         {
                             Id = pc.Id,
                             CompetitorId = pc.CompetitorId,
                             CompetitorName = pc.Competitor != null ? pc.Competitor.Name : null,
                             BrandId = p.BrandId,
                             BrandName = p.Brand != null ? p.Brand.Name : null,
                             CategoryId = p.CategoryId,
                             CategoryName = p.Category != null ? p.Category.Name : null,
                             ProductId = p.Id,
                             ProductName = p.ProductName,
                             VehicleGroupId = p.VehicleGrup.Id,
                             VehicleGroupName = pc.Product.VehicleGrup.Name,
                             VehicleTypeId = pc.Product.VehicleType.Id,
                             VehicleTypeName = pc.Product.VehicleType.Name,
                             Description = pc.Description,
                             MCurrency = pc.MCurrency,
                             RakipCurrency = pc.RakipCurrency,
                             ForeignCurrencyId = pc.ForeignCurrencyId,
                             ForeignCurrencyName = pc.ForeignCurrency.CurrencyName,
                             ImageFiles = pc.IntelligenceRecordFiles.Select(x => x.FileUrls),
                             CreatedDate = pc.CreatedDate,
                             UserId = pc.UserId,
                             UserLastName = pc.UserLastName,
                             RowNo = pc.RowNo
                         };
        List<IntelligenceRecordDto> dto = new List<IntelligenceRecordDto>();
        foreach (var item in joinedData)
        {
            dto.Add(new IntelligenceRecordDto()
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
                VehicleTypeName = item.VehicleTypeName,
                VehicleGroupName = item.VehicleGroupName,
                VehicleGroupId = item.VehicleGroupId,
                VehicleTypeId = item.VehicleTypeId,
                Description = item.Description,
                ForeignCurrencyId = item.ForeignCurrencyId,
                ForeignCurrencyName = item.ForeignCurrencyName,
                RakipCurrency = item.RakipCurrency,
                MCurrency = item.MCurrency,
                ImageFiles = item.ImageFiles,
                CreatedDate = item.CreatedDate,
                UserLastName = item.UserLastName,
                UserId = item.UserId,
                RowNo= item.RowNo,
            });
        }

        return dto;
    }
    public async Task<IList<IntelligenceRecordDto>> GetAllIIntelligenceDtoFilterAsync(string companyId, List<string> competitorIds, List<string> productIds, List<string> brandIds, List<string> categoryIds, List<string> vehiclegroup, List<string> vehicleype, DateTime startDate, DateTime endDate, string keyword)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);
        _queryProductRepository.SetDbContextInstance(_context);
        var prodcustrelQuery = _queryRepository.GetAll(false)
            .Include(pc => pc.Competitor)
            .Include(pc => pc.IntelligenceRecordFiles)
            .Include(pc => pc.Product)
            .Include(pc => pc.ForeignCurrency)
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
            prodcustrelQuery = prodcustrelQuery.Where(pc => pc.CreatedDate >= startDate && pc.CreatedDate <= endDate.AddDays(1));
        }
        else
        {
            if (vehiclegroup?.Any() == true)
            {
                productQuery = productQuery.Where(pc => pc.VehicleGrup != null && vehiclegroup.Contains(pc.VehicleGrup.Id));
            }
            if (vehicleype?.Any() == true)
            {
                productQuery = productQuery.Where(pc => pc.VehicleType != null && vehicleype.Contains(pc.VehicleType.Id));
            }
            if (competitorIds?.Any() == true)
            {
                prodcustrelQuery = prodcustrelQuery.Where(pc => competitorIds.Contains(pc.CompetitorId));
            }
            if (productIds?.Any() == true)
            {
                prodcustrelQuery = prodcustrelQuery.Where(pc => productIds.Contains(pc.ProductId));
            }
            if (brandIds?.Any() == true)
            {
                prodcustrelQuery = prodcustrelQuery.Where(pc => pc.Product != null && brandIds.Contains(pc.Product.BrandId));
            }
            if (categoryIds?.Any() == true)
            {
                prodcustrelQuery = prodcustrelQuery.Where(pc => pc.Product != null && categoryIds.Contains(pc.Product.CategoryId));
            }
            if (startDate != default && endDate != default)
            {
                prodcustrelQuery = prodcustrelQuery.Where(pc => pc.CreatedDate >= startDate && pc.CreatedDate <= endDate.AddDays(1));
            }
            if (!string.IsNullOrEmpty(keyword))
            {
                prodcustrelQuery = prodcustrelQuery.Where(pc =>
                    (pc.Description != null && pc.Description.Contains(keyword)) ||
                    (pc.Product.ProductName != null && pc.Product.ProductName.Contains(keyword)) ||
                    (pc.Product.Brand.Name != null && pc.Product.Brand.Name.Contains(keyword)) ||
                    (pc.Product.VehicleGrup != null && pc.Product.VehicleGrup.Name.Contains(keyword)) ||
                    (pc.Product.VehicleType != null && pc.Product.VehicleType.Name.Contains(keyword)) ||
                    (pc.Product.Category.Name != null && pc.Product.Category.Name.Contains(keyword))
                );
            }
        }
        var prodcustrel = await prodcustrelQuery.ToListAsync();
        var products = await productQuery.ToListAsync();
        var joinedData = from pc in prodcustrel
                         join p in products.DistinctBy(p => p.Id) on pc.ProductId equals p.Id
                         orderby pc.CreatedDate descending
                         select new IntelligenceRecordDto
                         {
                             Id = pc.Id,
                             CompetitorId = pc.CompetitorId,
                             CompetitorName = pc.Competitor != null ? pc.Competitor.Name : null,
                             BrandId = p.BrandId,
                             BrandName = p.Brand != null ? p.Brand.Name : null,
                             CategoryId = p.CategoryId,
                             CategoryName = p.Category != null ? p.Category.Name : null,
                             ProductId = p.Id,
                             ProductName = p.ProductName,
                             VehicleGroupId = p.VehicleGrup != null ? p.VehicleGrup.Id : null,
                             VehicleGroupName = p.VehicleGrup != null ? p.VehicleGrup.Name : null,
                             VehicleTypeId = p.VehicleType != null ? p.VehicleType.Id : null,
                             VehicleTypeName = p.VehicleType != null ? p.VehicleType.Name : null,
                             Description = pc.Description,
                             MCurrency = pc.MCurrency,
                             RakipCurrency = pc.RakipCurrency,
                             ForeignCurrencyId = pc.ForeignCurrencyId,
                             ForeignCurrencyName = pc.ForeignCurrency != null ? pc.ForeignCurrency.CurrencyName : null,
                             ImageFiles = pc.IntelligenceRecordFiles.Select(x => x.FileUrls),
                             CreatedDate = pc.CreatedDate,
                             UserId = pc.UserId,
                             UserLastName = pc.UserLastName,
                             RowNo=(int)pc.RowNo,
                         };
        return joinedData.Distinct().ToList();
    }
    public async Task<IList<IntelligenceRecordDto>> GetFilteredIntelligenceRecordsAsync(string companyId, IList<string> competitorIds)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);
        _queryProductRepository.SetDbContextInstance(_context);
        List<IntelligenceRecordDto> filteredRecords = new List<IntelligenceRecordDto>();
        foreach (var competitorIdLoop in competitorIds)
        {
            var prodcustrel = await _queryRepository.GetAll().Include("Competitor").Include("IntelligenceRecordFiles")
                .Include("ForeignCurrency").Include("Product")
                .Where(pc => pc.CompetitorId == competitorIdLoop || pc.ProductId == pc.ProductId)
                .OrderByDescending(pc => pc.CreatedDate).ToListAsync();
            var product = await _queryProductRepository.GetAll().Include("VehicleType").Include("VehicleGrup")
                .Include("Brand").Include("Category").ToListAsync();
            var joinedData = (from pc in prodcustrel
                              join p in product on pc.ProductId equals p.Id
                              select new IntelligenceRecordDto
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
                                  ForeignCurrencyId = pc.ForeignCurrencyId,
                                  ForeignCurrencyName = pc.ForeignCurrency.CurrencyName,
                                  MCurrency = pc.MCurrency,
                                  RakipCurrency = pc.RakipCurrency,
                                  VehicleGroupId = p.VehicleGrup.Id,
                                  VehicleGroupName = p.VehicleGrup.Name,
                                  VehicleTypeId = pc.Product.VehicleType.Id,
                                  VehicleTypeName = pc.Product.VehicleType.Name,
                                  ImageFiles = pc.IntelligenceRecordFiles.Select(x => x.FileUrls),
                                  CreatedDate = pc.CreatedDate,
                                  UserId = pc.UserId,
                                  UserLastName = pc.UserLastName,

                                  //ImageUrl = pc.ImageUrl,
                                  //FieldFeedback = pc.FieldFeedback,
                                  //Location = pc.Location,
                                  //Explanation = pc.Explanation,
                              }).ToList();

            filteredRecords.AddRange(joinedData.Take(5).OrderDescending());
        }

        return filteredRecords;
    }
    public async Task<IList<IntelligenceRecordDto>> HomeGetTopIntelligenceRecordAsync(string companyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);
        _queryProductRepository.SetDbContextInstance(_context);
        var prodcustrel = await _queryRepository.GetAll().Include("Competitor").Include("Product")
            .Include("ForeignCurrency").Include("IntelligenceRecordFiles").ToListAsync();
        var product = await _queryProductRepository.GetAll().Include("VehicleType").Include("VehicleGrup")
            .Include("Brand").Include("Category").ToListAsync();
        var joinedData = (from pc in prodcustrel
                          join p in product on pc.ProductId equals p.Id
                          orderby pc.CreatedDate descending // Order by CreatedDate in descending order
                          select new IntelligenceRecordDto
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
                              MCurrency = pc.MCurrency,
                              RakipCurrency = pc.RakipCurrency,
                              ForeignCurrencyName = pc.ForeignCurrency.CurrencyName,
                              ForeignCurrencyId = pc.ForeignCurrency.Id,
                              VehicleGroupId = p.VehicleGrup.Id,
                              VehicleGroupName = pc.Product.VehicleGrup.Name,
                              VehicleTypeId = pc.Product.VehicleType.Id,
                              VehicleTypeName = pc.Product.VehicleType.Name,
                              ImageFiles = pc.IntelligenceRecordFiles.Select(x => x.FileUrls),
                              CreatedDate = pc.CreatedDate,
                              UserLastName = pc.UserLastName,
                              UserId = pc.UserId,
                          }).Take(12).ToList();

        List<IntelligenceRecordDto> dto = new();
        foreach (var item in joinedData)
        {
            //var imageFiles = item.ImageFiles.Any() ? item.ImageFiles : new List<string> { "48415080.jpg" };

            dto.Add(new IntelligenceRecordDto()
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
                ForeignCurrencyId = item.ForeignCurrencyId,
                ForeignCurrencyName = item.ForeignCurrencyName,
                RakipCurrency = item.RakipCurrency,
                MCurrency = item.MCurrency,
                VehicleTypeName = item.VehicleTypeName,
                VehicleGroupName = item.VehicleGroupName,
                VehicleGroupId = item.VehicleGroupId,
                VehicleTypeId = item.VehicleTypeId,
                Description = item.Description,
                ImageFiles = item.ImageFiles,
                CreatedDate = item.CreatedDate,
                UserId = item.UserId,
                UserLastName = item.UserLastName,
            });
        }

        return dto;
    }
    public async Task<IList<IntelligenceByIdDto>> GetByIdIntelligenceRecordsAsync(string id, string companyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);
        _queryProductRepository.SetDbContextInstance(_context);
        var intelligence = await _queryRepository.GetWhere(x => x.Id == id, false).Include("Competitor")
            .Include("IntelligenceRecordFiles").Include("Product").Include("ForeignCurrency").ToListAsync();
        var product = await _queryProductRepository.GetAll().Include("VehicleType").Include("VehicleGrup")
            .Include("Brand").Include("Category").ToListAsync();
        var joinedData = (from pc in intelligence
                          join p in product on pc.ProductId equals p.Id
                          orderby pc.CreatedDate descending
                          select new IntelligenceByIdDto
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
                              VehicleGroupId = p.VehicleGrup.Id,
                              VehicleGroupName = p.VehicleGrup.Name,
                              VehicleTypeId = p.VehicleType.Id,
                              VehicleTypeName = p.VehicleType.Name,
                              MCurrency = pc.MCurrency,
                              RakipCurrency = pc.RakipCurrency,
                              ForeignCurrencyId = pc.ForeignCurrencyId,
                              ForeignCurrencyName = pc.ForeignCurrency.CurrencyName,
                              ImageFiles = pc.IntelligenceRecordFiles.Select(x => x.FileUrls),
                              CreateDate = pc.CreatedDate,
                              UserId = pc.UserId,
                              UserLastName = pc.UserLastName,
                              RowNo=pc.RowNo,
                          }).Take(5).ToList();

        List<IntelligenceByIdDto> dto = new List<IntelligenceByIdDto>();
        foreach (var item in joinedData)
        {
            dto.Add(new IntelligenceByIdDto()
            {
                Id = item.Id,
                BrandId = item.BrandId,
                BrandName = item.BrandName,
                CategoryId = item.CategoryId,
                CategoryName = item.CategoryName,
                CompetitorId = item.CompetitorId,
                CompetitorName = item.CompetitorName,
                Description = item.Description,
                ProductId = item.ProductId,
                ProductName = item.ProductName,
                VehicleGroupId = item.VehicleGroupId,
                VehicleGroupName = item.VehicleGroupName,
                VehicleTypeId = item.VehicleTypeId,
                VehicleTypeName = item.VehicleTypeName,
                ForeignCurrencyId = item.ForeignCurrencyId,
                ForeignCurrencyName = item.ForeignCurrencyName,
                RakipCurrency = item.RakipCurrency,
                MCurrency = item.MCurrency,
                ImageFiles = item.ImageFiles,
                CreateDate = item.CreateDate,
                UserLastName = item.UserLastName,
                UserId = item.UserId,
                RowNo=item.RowNo,
            });
        }

        return dto;
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
            RowNo=pc.RowNo,
            UserLastName = pc.UserLastName,
        }).ToList();

        return dtoList;
    }
}
//public async Task<IList<IntelligenceRecordDto>> GetAllIIntelligenceDtoFilterAsync(string companyId, List<string> competitorIds, List<string> productIds, List<string> brandIds, List<string> categoryIds, DateTime startDate, DateTime endDate, string keyword)
//{
//    _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
//    _queryRepository.SetDbContextInstance(_context);
//    _queryProductRepository.SetDbContextInstance(_context);

//    // Başlangıç sorguları
//    var prodcustrelQuery = _queryRepository.GetAll(false)
//        .Include(pc => pc.Competitor)
//        .Include(pc => pc.IntelligenceRecordFiles)
//        .Include(pc => pc.Product)
//        .Include(pc => pc.ForeignCurrency)
//        .AsQueryable();

//    var productQuery = _queryProductRepository.GetAll(false)
//        .Include(p => p.VehicleType)
//        .Include(p => p.VehicleGrup)
//        .Include(p => p.Brand)
//        .Include(p => p.Category)
//        .AsQueryable();

//    // Filtreler
//    if (competitorIds?.Any() == true)
//    {
//        prodcustrelQuery = prodcustrelQuery.Where(pc => competitorIds.Contains(pc.CompetitorId));
//    }

//    if (productIds?.Any() == true)
//    {
//        prodcustrelQuery = prodcustrelQuery.Where(pc => productIds.Contains(pc.ProductId));
//    }

//    if (brandIds?.Any() == true)
//    {
//        prodcustrelQuery = prodcustrelQuery.Where(pc => pc.Product != null && brandIds.Contains(pc.Product.BrandId));
//    }

//    if (categoryIds?.Any() == true)
//    {
//        prodcustrelQuery = prodcustrelQuery.Where(pc => pc.Product != null && categoryIds.Contains(pc.Product.CategoryId));
//    }

//    if (startDate != default && endDate != default)
//    {
//        prodcustrelQuery = prodcustrelQuery.Where(pc => pc.CreatedDate >= startDate && pc.CreatedDate <= endDate.AddDays(1));
//    }

//    // if (startDate != default && endDate != default)
//    // {
//    //     prodcustrelQuery = prodcustrelQuery.Where(pc => pc.CreatedDate >= startDate && pc.CreatedDate <= endDate);
//    // }

//    var prodcustrel = await prodcustrelQuery.ToListAsync();
//    var products = await productQuery.ToListAsync();
//    var joinedData = from pc in prodcustrel
//        join p in products on pc.ProductId equals p.Id
//        orderby pc.CreatedDate descending
//        select new IntelligenceRecordDto
//        {
//            Id = pc.Id,
//            CompetitorId = pc.CompetitorId,
//            CompetitorName = pc.Competitor != null ? pc.Competitor.Name : null,
//            BrandId = p.BrandId,
//            BrandName = p.Brand != null ? p.Brand.Name : null,
//            CategoryId = p.CategoryId,
//            CategoryName = p.Category != null ? p.Category.Name : null,
//            ProductId = p.Id,
//            ProductName = p.ProductName,
//            VehicleGroupId = p.VehicleGrup != null ? p.VehicleGrup.Id : null,
//            VehicleGroupName = p.VehicleGrup != null ? p.VehicleGrup.Name : null,
//            VehicleTypeId = p.VehicleType != null ? p.VehicleType.Id : null,
//            VehicleTypeName = p.VehicleType != null ? p.VehicleType.Name : null,
//            Description = pc.Description,
//            MCurrency = pc.MCurrency,
//            RakipCurrency = pc.RakipCurrency,
//            ForeignCurrencyId = pc.ForeignCurrencyId,
//            ForeignCurrencyName = pc.ForeignCurrency != null ? pc.ForeignCurrency.CurrencyName : null,
//            ImageFiles = pc.IntelligenceRecordFiles.Select(x => x.FileUrls),
//            CreatedDate = pc.CreatedDate,
//            UserId = pc.UserId,
//            UserLastName = pc.UserLastName,
//        };
//    var dtoList = joinedData.ToList();

//    return dtoList;
//}
//public async Task<IList<IntelligenceRecord>> GetAllIntelligenceRecordAsync(string companyId)
//{
//    _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
//    _queryRepository.SetDbContextInstance(_context);


//    var competitorProducts = _queryRepository.GetAll(false)
//    .Where(ir => ir.Product != null && ir.Competitor != null)
//    .Select(ir => new
//    {
//        ProductName = ir.Product.ProductName,
//        CompetitorName = ir.Competitor.Name,
//        CurrencyTL = ir.CurrencyTl,
//        CurrencyDolor = ir.CurrencyDolor,
//        CurrencyEuro = ir.CurrencyEuro
//    })
//    .ToList();
//    return await _queryRepository.GetAll().AsNoTracking().ToListAsync();
//}