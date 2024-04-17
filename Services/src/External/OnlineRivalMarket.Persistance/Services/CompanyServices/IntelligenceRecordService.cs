using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineRivalMarket.Application.Features.CompanyFeatures.IntelligenceRecordFeatures.Commands.CreateIntelligenceRecord;
using OnlineRivalMarket.Application.Services.CompanyServices;
using OnlineRivalMarket.Domain;
using OnlineRivalMarket.Domain.CompanyEntities;
using OnlineRivalMarket.Domain.Dtos;
using OnlineRivalMarket.Domain.Repositories.CompanyDbContext.IntelligenceRecordRepository;
using OnlineRivalMarket.Domain.Repositories.CompanyDbContext.ProductRepositories;
using OnlineRivalMarket.Domain.UnitOfWorks;
using OnlineRivalMarket.Persistance.Context;
namespace OnlineRivalMarket.Persistance.Services.CompanyServices
{
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
            _commandRepository.SetDbContextInstance(_context);
            _unitOfWork.SetDbContextInstance(_context);
            IntelligenceRecord record = _mapper.Map<IntelligenceRecord>(requset);
            record.Id = Guid.NewGuid().ToString();
            await _commandRepository.AddAsync(record, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return record;
        }
        public async Task<IList<IntelligenceRecord>> GetAllIntelligenceRecordAsync(string companyId)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
            _queryRepository.SetDbContextInstance(_context);
            return await _queryRepository.GetAll().AsNoTracking().ToListAsync();
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
                                 CompetitorId =pc.CompetitorId,
                                 CompetitorName = pc.Competitor != null ? pc.Competitor.Name : null,
                                 
                                 BrandId = p.BrandId,
                                 BrandName = p.Brand != null ? p.Brand.Name : null,
                                 
                                 
                                 CategoryId = p.CategoryId,
                                 CategoryName = p.Category != null ? p.Category.Name : null, // Assuming Category is still available in Product
                                 
                                 
                                 ProductId = p.Id,
                                 ProductName = p.ProductName,
                                
                                 VehicleTypeId = p.VehicleTypeId,
                                 VehicleGroupName = p.VehicleGrup != null ? p.VehicleGrup.Name : null,
                                 

                                 VehicleGroupId = p.VehicleGroupId,
                                 VehicleTypeName = p.VehicleType != null ? p.VehicleType.Name : null,
                                 
                                 
                                 
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
                    Explanation = item.Explanation,
                    RakipTl = item.RakipTl,
                    RakipEuro = item.RakipEuro,
                    RakipDolor = item.RakipDolor,
                    ImageUrl = item.ImageUrl,
                    CurrencyTl = item.CurrencyTl,
                    CurrencyEuro = item.CurrencyEuro,
                    CurrencyDolor = item.CurrencyDolor,
                    VehicleTypeName = item.VehicleTypeName,
                    VehicleGroupName = item.VehicleGroupName,
                    Region = item.Region,
                    Location = item.Location,
                    IntelligenceType = item.IntelligenceType,
                    FieldFeedback = item.FieldFeedback,
                    Description = item.Description,
                });
            }

            return dto;
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
                                  VehicleGroupId = pc.Product.VehicleGrup.Id,
                                  VehicleGroupName = pc.Product.VehicleGrup.Name,

                                  VehicleTypeId = pc.Product.VehicleType.Id,
                                  VehicleTypeName = pc.Product.VehicleType.Name,
                                  Explanation = pc.Explanation,
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
}
