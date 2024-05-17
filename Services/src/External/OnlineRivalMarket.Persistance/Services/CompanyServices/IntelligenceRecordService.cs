using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineRivalMarket.Application.Features.CompanyFeatures.IntelligenceRecordFeatures.Commands.CreateIntelligenceRecord;
using OnlineRivalMarket.Application.Services.CompanyServices;
using OnlineRivalMarket.Domain;
using OnlineRivalMarket.Domain.CompanyEntities;
using OnlineRivalMarket.Domain.Dtos;
using OnlineRivalMarket.Domain.Dtos.IntelligenceDto;
using OnlineRivalMarket.Domain.Repositories.CompanyDbContext.IntelligenceRecordRepository;
using OnlineRivalMarket.Domain.Repositories.CompanyDbContext.ProductRepositories;
using OnlineRivalMarket.Domain.UnitOfWorks;
using OnlineRivalMarket.Persistance.Context;
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
        _commandRepository = commandRepository; _queryRepository = queryRepository; _unitOfWork = unitOfWork; _contextService = contextService; _mapper = mapper; _queryProductRepository = queryProductRepository;
    }
    public async Task<IntelligenceRecord> CreateIntelligenceRecordAsync(CreateIntelligenceRecordCommand requset, CancellationToken cancellationToken)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(requset.CompanyId);
        _commandRepository.SetDbContextInstance(_context);
        _unitOfWork.SetDbContextInstance(_context);
        IntelligenceRecord record = _mapper.Map<IntelligenceRecord>(requset);
        record.Id = Guid.NewGuid().ToString();
        await _commandRepository.AddAsync(record, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return record;
    }
    public async Task<IList<IntelligenceRecordDto>> GetAllDtoAsync(string companyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);
        _queryProductRepository.SetDbContextInstance(_context);
        var prodcustrel = await _queryRepository.GetAll().Include("Competitor").Include("IntelligenceRecordFiles").Include("Product").Include("ForeignCurrency").ToListAsync();
        var product = await _queryProductRepository.GetAll().Include("VehicleType").Include("VehicleGrup").Include("Brand").Include("Category").ToListAsync();

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
                             CreatedDate=pc.CreatedDate
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
                CreatedDate = item.CreatedDate
                //Explanation = item.Explanation,
                //ImageUrl = item.ImageUrl,
                //Region = item.Region,
                //Location = item.Location,
                //IntelligenceType = item.IntelligenceType,
                //FieldFeedback = item.FieldFeedback,
            });
        }

        return dto;
    }
    public async Task<IList<IntelligenceByIdDto>> GetByIdIntelligenceRecordsAsync(string id, string companyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);
        _queryProductRepository.SetDbContextInstance(_context);
        var intelligence = await _queryRepository.GetWhere(x => x.Id == id, false).Include("Competitor").Include("IntelligenceRecordFiles").Include("Product").Include("ForeignCurrency").ToListAsync();
        var product = await _queryProductRepository.GetAll().Include("VehicleType").Include("VehicleGrup").Include("Brand").Include("Category").ToListAsync();
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
                              CreateDate=pc.CreatedDate
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
                CreateDate=item.CreateDate
            });
        }
        return dto;
    }
    public async Task<IList<IntelligenceRecordDto>> GetFilteredIntelligenceRecordsAsync(string companyId, IList<string> competitorIds)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);
        _queryProductRepository.SetDbContextInstance(_context);
        List<IntelligenceRecordDto> filteredRecords = new List<IntelligenceRecordDto>();
        foreach (var competitorIdLoop in competitorIds)
        {
            var prodcustrel = await _queryRepository.GetAll().Include("Competitor").Include("IntelligenceRecordFiles").Include("ForeignCurrency").Include("Product").Where(pc => pc.CompetitorId == competitorIdLoop || pc.ProductId == pc.ProductId).OrderByDescending(pc => pc.CreatedDate).ToListAsync();
            var product = await _queryProductRepository.GetAll().Include("VehicleType").Include("VehicleGrup").Include("Brand").Include("Category").ToListAsync();
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

                                  //ImageUrl = pc.ImageUrl,
                                  //FieldFeedback = pc.FieldFeedback,
                                  //Location = pc.Location,
                                  //Explanation = pc.Explanation,
                              }).ToList();

            filteredRecords.AddRange(joinedData.Take(5));
        }
        return filteredRecords;
    }
    public async Task<IList<IntelligenceRecordDto>> HomeGetTopIntelligenceRecordAsync(string companyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);
        _queryProductRepository.SetDbContextInstance(_context);
        var prodcustrel = await _queryRepository.GetAll().Include("Competitor").Include("Product").Include("ForeignCurrency").Include("IntelligenceRecordFiles").ToListAsync();
        var product = await _queryProductRepository.GetAll().Include("VehicleType").Include("VehicleGrup").Include("Brand").Include("Category").ToListAsync();
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
            });
        }
        return dto;
    }
}

































































































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