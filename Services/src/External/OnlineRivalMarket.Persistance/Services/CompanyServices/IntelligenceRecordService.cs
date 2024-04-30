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
        var prodcustrel = await _queryRepository.GetAll().Include("Competitor").Include("Product").ToListAsync();
        var product = await _queryProductRepository.GetAll().Include("VehicleType").Include("VehicleGrup").Include("Brand").Include("Category").ToListAsync();

        var joinedData = from pc in prodcustrel
                         join p in product on pc.ProductId equals p.Id
                         select new IntelligenceRecordDto
                         {
                             //CompetitorId = pc.CompetitorId,
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
                             Explanation = pc.Explanation,
                             RakipTl = pc.RakipTl,
                             RakipEuro = pc.RakipEuro,
                             RakipDolor = pc.RakipDolor,
                             ImageUrl = pc.ImageUrl,
                             CurrencyTl = pc.CurrencyTl,
                             CurrencyEuro = pc.CurrencyEuro,
                             CurrencyDolor = pc.CurrencyDolor,
                             Description = pc.Description,
                             FieldFeedback = pc.FieldFeedback,
                             Location = pc.Location,
                             IntelligenceType = (int)pc.IntelligenceType,
                             Region = (int)pc.Region,
                         };
        List<IntelligenceRecordDto> dto = new List<IntelligenceRecordDto>();
        foreach (var item in joinedData)
        {
            dto.Add(new IntelligenceRecordDto()
            {
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
                Explanation = item.Explanation,
                RakipTl = item.RakipTl,
                RakipEuro = item.RakipEuro,
                RakipDolor = item.RakipDolor,
                ImageUrl = item.ImageUrl,
                CurrencyTl = item.CurrencyTl,
                CurrencyEuro = item.CurrencyEuro,
                CurrencyDolor = item.CurrencyDolor,
                Region = item.Region,
                Location = item.Location,
                IntelligenceType = item.IntelligenceType,
                FieldFeedback = item.FieldFeedback,
                Description = item.Description,
            });
        }

        return dto;
    }

    public async Task<IList<IntelligenceByIdDto>> GetByIdIntelligenceRecordsAsync(string id, string companyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);
        _queryProductRepository.SetDbContextInstance(_context);
        var intelligence = await _queryRepository.GetWhere(x => x.Id == id, false).Include("Competitor").Include("Product").ToListAsync();
        var product = await _queryProductRepository.GetAll().Include("VehicleType").Include("VehicleGrup").Include("Brand").Include("Category").ToListAsync();
        var joinedData = (from pc in intelligence
                          join p in product on pc.ProductId equals p.Id
                          orderby pc.CreatedDate descending
                          select new IntelligenceByIdDto
                          {
                              CompetitorId = pc.CompetitorId,
                              CompetitorName = pc.Competitor != null ? pc.Competitor.Name : null,
                              BrandId = p.BrandId,
                              BrandName = p.Brand.Name,
                              CategoryId = p.CategoryId,
                              CategoryName = p.Category.Name,
                              ProductId = p.Id,
                              ProductName = p.ProductName,
                              Description = pc.Description,
                              RakipTl = pc.RakipTl,
                              RakipEuro = pc.RakipEuro,
                              RakipDolor = pc.RakipDolor,
                              ImageUrl = pc.ImageUrl,
                              CurrencyTl = pc.CurrencyTl,
                              CurrencyEuro = pc.CurrencyEuro,
                              CurrencyDolor = pc.CurrencyDolor,
                              FieldFeedback = pc.FieldFeedback,
                              Location = pc.Location,
                              VehicleGroupId = p.VehicleGrup.Id,
                              VehicleGroupName = p.VehicleGrup.Name,
                              VehicleTypeId = p.VehicleType.Id,
                              VehicleTypeName = p.VehicleType.Name,
                              Explanation = pc.Explanation,
                              IntelligenceType = (int)pc.IntelligenceType,
                              Region = (int)pc.Region,
                          }).Take(5).ToList();

        List<IntelligenceByIdDto> dto = new List<IntelligenceByIdDto>();
        foreach (var item in joinedData)
        {
            dto.Add(new IntelligenceByIdDto()
            {
                BrandId = item.BrandId,
                BrandName = item.BrandName,
                CategoryId = item.CategoryId,
                CategoryName = item.CategoryName,
                CompetitorId = item.CompetitorId,
                CompetitorName = item.CompetitorName,
                CurrencyDolor = item.CurrencyDolor,
                CurrencyEuro = item.CurrencyEuro,
                CurrencyTl = item.CurrencyTl,
                Description = item.Description,
                Explanation = item.Explanation,
                FieldFeedback = item.FieldFeedback,
                ImageUrl = item.ImageUrl,
                IntelligenceType = item.IntelligenceType,
                Location = item.Location,
                ProductId = item.ProductId,
                ProductName = item.ProductName,
                RakipDolor = item.RakipDolor,
                RakipEuro = item.RakipEuro,
                RakipTl = item.RakipTl,
                Region = item.Region,
                VehicleGroupId = item.VehicleGroupId,
                VehicleGroupName = item.VehicleGroupName,
                VehicleTypeId = item.VehicleTypeId,
                VehicleTypeName = item.VehicleTypeName
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
            var prodcustrel = await _queryRepository.GetAll().Include("Competitor").Include("Product").Where(pc => pc.CompetitorId == competitorIdLoop).OrderByDescending(pc => pc.CreatedDate).ToListAsync();
            var product = await _queryProductRepository.GetAll().Include("VehicleType").Include("VehicleGrup").Include("Brand").Include("Category").ToListAsync();
            var joinedData = (from pc in prodcustrel
                              join p in product on pc.ProductId equals p.Id
                              select new IntelligenceRecordDto
                              {
                                  CompetitorId = pc.CompetitorId,
                                  CompetitorName = pc.Competitor != null ? pc.Competitor.Name : null,
                                  BrandId = p.BrandId,
                                  BrandName = p.Brand.Name,
                                  CategoryId = p.CategoryId,
                                  CategoryName = p.Category.Name,
                                  ProductId = p.Id,
                                  ProductName = p.ProductName,
                                  Description = pc.Description,
                                  RakipTl = pc.RakipTl,
                                  RakipEuro = pc.RakipEuro,
                                  RakipDolor = pc.RakipDolor,
                                  ImageUrl = pc.ImageUrl,
                                  CurrencyTl = pc.CurrencyTl,
                                  CurrencyEuro = pc.CurrencyEuro,
                                  CurrencyDolor = pc.CurrencyDolor,
                                  FieldFeedback = pc.FieldFeedback,
                                  Location = pc.Location,
                                  VehicleGroupId = p.VehicleGrup.Id,
                                  VehicleGroupName = p.VehicleGrup.Name,
                                  VehicleTypeId = pc.Product.VehicleType.Id,
                                  VehicleTypeName = pc.Product.VehicleType.Name,
                                  Explanation = pc.Explanation,
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
        var prodcustrel = await _queryRepository.GetAll().Include("Competitor").Include("Product").ToListAsync();
        var product = await _queryProductRepository.GetAll().Include("VehicleType").Include("VehicleGrup").Include("Brand").Include("Category").ToListAsync();

        var joinedData = (from pc in prodcustrel
                          join p in product on pc.ProductId equals p.Id
                          orderby pc.CreatedDate descending
                          select new IntelligenceRecordDto
                          {
                              CompetitorId = pc.CompetitorId,
                              CompetitorName = pc.Competitor != null ? pc.Competitor.Name : null,
                              BrandId = p.BrandId,
                              BrandName = p.Brand.Name,
                              CategoryId = p.CategoryId,
                              CategoryName = p.Category.Name,
                              ProductId = p.Id,
                              ProductName = p.ProductName,
                              Description = pc.Description,
                              RakipTl = pc.RakipTl,
                              RakipEuro = pc.RakipEuro,
                              RakipDolor = pc.RakipDolor,
                              ImageUrl = pc.ImageUrl,
                              CurrencyTl = pc.CurrencyTl,
                              CurrencyEuro = pc.CurrencyEuro,
                              CurrencyDolor = pc.CurrencyDolor,
                              FieldFeedback = pc.FieldFeedback,
                              Location = pc.Location,
                              VehicleGroupId = p.VehicleGrup.Id,
                              VehicleGroupName = pc.Product.VehicleGrup.Name,
                              VehicleTypeId = pc.Product.VehicleType.Id,
                              VehicleTypeName = pc.Product.VehicleType.Name,
                              Explanation = pc.Explanation,
                              IntelligenceType = (int)pc.IntelligenceType,
                              Region = (int)pc.Region,
                          }).Take(5).ToList();

        List<IntelligenceRecordDto> dto = new();
        foreach (var item in joinedData)
        {
            dto.Add(new IntelligenceRecordDto()
            {
                CompetitorId = item.CompetitorId,
                CompetitorName = item.CompetitorName,
                BrandId = item.BrandId,
                BrandName = item.BrandName,
                CategoryId = item.CategoryId,
                CategoryName = item.CategoryName,
                ProductId = item.ProductId,
                ProductName = item.ProductName,
                RakipTl = item.RakipTl,
                RakipEuro = item.RakipEuro,
                RakipDolor = item.RakipDolor,
                ImageUrl = item.ImageUrl,
                CurrencyTl = item.CurrencyTl,
                CurrencyEuro = item.CurrencyEuro,
                CurrencyDolor = item.CurrencyDolor,
                VehicleTypeName = item.VehicleTypeName,
                VehicleGroupName = item.VehicleGroupName,
                VehicleGroupId = item.VehicleGroupId,
                VehicleTypeId = item.VehicleTypeId,
                Explanation = item.Explanation,
                Region = item.Region,
                Location = item.Location,
                IntelligenceType = item.IntelligenceType,
                FieldFeedback = item.FieldFeedback,
                Description = item.Description

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