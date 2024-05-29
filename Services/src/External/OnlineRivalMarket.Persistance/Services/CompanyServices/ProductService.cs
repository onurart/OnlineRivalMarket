using EntityFrameworkCorePagination.Nuget.Pagination;
using OnlineRivalMarket.Application.Features.CompanyFeatures.ProductFeatures.Queries;
using OnlineRivalMarket.Application.Services.CompanyServices;
using OnlineRivalMarket.Domain;
using OnlineRivalMarket.Domain.Dtos;
using OnlineRivalMarket.Domain.Dtos.Product;

namespace OnlineRivalMarket.Persistance.Services.CompanyServices
{
    public sealed class ProductService : IProductService
    {
        private readonly IProductCommandRepository _commandRepository;
        private readonly IProductQueryRepository _queryRepository;
        private readonly IVehicleGroupQueryRepository _vehicleGroupQueryRepository;
        private readonly IVehicleTypeQuertRepository _vehicleTypeQuertRepository;
        private readonly IContextService _contextService;
        private readonly ICompanyDbUnitOfWork _companyDbUnitOfWork;
        private readonly IMapper _mapper;
        private CompanyDbContext _context;
        public ProductService(IProductCommandRepository commandRepository, IProductQueryRepository queryRepository, IContextService contextService, ICompanyDbUnitOfWork companyDbUnitOfWork, IMapper mapper, IVehicleGroupQueryRepository vehicleGroupQueryRepository = null, IVehicleTypeQuertRepository vehicleTypeQuertRepository = null)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
            _contextService = contextService;
            _companyDbUnitOfWork = companyDbUnitOfWork;
            _mapper = mapper;
            _vehicleGroupQueryRepository = vehicleGroupQueryRepository;
            _vehicleTypeQuertRepository = vehicleTypeQuertRepository;
        }
        public async Task<Product> CreateProductAsync(CreateProductCommand requst, CancellationToken cancellationToken)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(requst.CompanyId);
            _commandRepository.SetDbContextInstance(_context);
            _companyDbUnitOfWork.SetDbContextInstance(_context);
            Product product = _mapper.Map<Product>(requst);
            product.Id = Guid.NewGuid().ToString();
            await _commandRepository.AddAsync(product, cancellationToken);
            await _companyDbUnitOfWork.SaveChangesAsync(cancellationToken);
            return product;
        }
        public async Task<PaginationResult<ProductDto>> GetAllProductPaginationAsync(GetAllProductQuery request)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
            _queryRepository.SetDbContextInstance(_context);
            PaginationResult<Product> result = await _queryRepository.GetAll(false).ToPagedListAsync(request.PageSize, request.PageNumber);
            int count = _queryRepository.GetAll().Count();

            IList<ProductDto> list = new List<ProductDto>();
            var prodcustrel = await _queryRepository.GetAll().Include("VehicleType").Include("VehicleGrup").ToListAsync();
            var product = await _queryRepository.GetAll().Include("Category").Include("Brand").ToListAsync();
            var joinedData = (from pc in prodcustrel
                              join p in product on pc.Id equals p.Id
                              orderby pc.CreatedDate descending
                              select new ProductDto
                              {
                                  Id = pc.Id,
                                  ProducerCode = p.ProducerCode,
                                  ProductName = p.ProductName,
                                  ProductCode = p.ProductCode,
                                  VehicleTypeId = pc.VehicleTypeId,
                                  VehicleTypeName = p.VehicleType.Name,
                                  VehicleGroupId = p.VehicleGroupId,
                                  VehicleGroupName = p.VehicleGrup.Name,
                                  BrandId = p.BrandId,
                                  BrandName = p.Brand.Name,
                                  CategoryId = p.CategoryId,
                                  CategoryName = p.Category.Name,
                              }).ToList();

            var paginatedData = joinedData
                .Skip((result.PageNumber - 1) * result.PageSize)
                .Take(result.PageSize)
                .ToList();

            PaginationResult<ProductDto> paginationResult = new PaginationResult<ProductDto>(
                pageNumber: result.PageNumber,
                pageSize: result.PageSize,
                totalCount: count,
                datas: paginatedData

            );

            return paginationResult;
        }

        public async Task<IList<ProductDto>> GetAllProduct(string companyId)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
            _queryRepository.SetDbContextInstance(_context);

            var prodcustrelQuery = _queryRepository.GetAll(false)
                .Include(pc => pc.VehicleGrup)
                .Include(x => x.VehicleType)
                .Include(x => x.Brand).AsQueryable();
            var productQuery = _queryRepository.GetAll(false)
                 .Include(p => p.VehicleType)
                 .Include(p => p.VehicleGrup)
                 .Include(p => p.Brand)
                 .Include(p => p.Category)
                 .AsQueryable();
            var prodcustrel = await prodcustrelQuery.ToListAsync();
            var products = await productQuery.ToListAsync();
            var joinedData = from pc in prodcustrel
                             join p in products.DistinctBy(p => p.Id) on pc.Id equals p.Id
                             orderby pc.CreatedDate descending
                             select new ProductDto
                             {
                                 Id = pc.Id,
                                 CreateDate = pc.CreatedDate,
                                 ProducerCode = pc.ProducerCode,
                                 ProductCode=pc.ProductCode,
                                 BrandId = p.BrandId,
                                 BrandName = p.Brand != null ? p.Brand.Name : null,
                                 CategoryId = p.CategoryId,
                                 CategoryName = p.Category != null ? p.Category.Name : null,
                                 ProductName = p.ProductName,
                                 VehicleGroupId = p.VehicleGrup != null ? p.VehicleGrup.Id : null,
                                 VehicleGroupName = p.VehicleGrup != null ? p.VehicleGrup.Name : null,
                                 VehicleTypeId = p.VehicleType != null ? p.VehicleType.Id : null,
                                 VehicleTypeName = p.VehicleType != null ? p.VehicleType.Name : null
                             };
            return joinedData.Distinct().ToList();
        }

        public async Task<IList<ProductSelectList>> GetSelectListAsync(string companyId)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
            _queryRepository.SetDbContextInstance(_context);
            return await _queryRepository
                        .GetAll()
                        .AsNoTracking()
                        .Select(p => new ProductSelectList { Id = p.Id, ProductName = p.ProductName })
                        .ToListAsync();
        }
        public async Task UpdateAsync(Product product, string companyId)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
            _queryRepository.SetDbContextInstance(_context);
            _companyDbUnitOfWork.SetDbContextInstance(_context);
            _commandRepository.Update(product);
            await _companyDbUnitOfWork.SaveChangesAsync();
        }

      
    }
}














//public async Task<IList<ProductDto>> GetAllAsync(GetAllProductQuery request)
//{
//    _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
//    _queryRepository.SetDbContextInstance(_context);
//    await _queryRepository.GetAll().AsNoTracking().ToListAsync();


//    var prodcustrel = await _queryRepository.GetAll().Include("VehicleType").Include("VehicleGrup").ToListAsync();
//    var product = await _queryRepository.GetAll().Include("Category").Include("Brand").ToListAsync();
//    var joinedData = (from pc in prodcustrel
//                      join p in product on pc.Id equals p.Id
//                      orderby pc.CreatedDate descending
//                      select new ProductDto
//                      {
//                          Id = pc.Id,
//                          ProducerCode = p.ProducerCode,
//                          ProductName = p.ProductName,
//                          ProductCode = p.ProductCode,
//                          VehicleTypeId = pc.VehicleTypeId,
//                          VehicleTypeName = p.VehicleType.Name,
//                          VehicleGroupId = p.VehicleGroupId,
//                          VehicleGroupName = p.VehicleGrup.Name,
//                          BrandId = p.BrandId,
//                          BrandName = p.Brand.Name,
//                          CategoryId = p.CategoryId,
//                          CategoryName = p.Category.Name,
//                          CreateDate=pc.CreatedDate
//                      }).ToList();
//    List<ProductDto> dto = new List<ProductDto>();
//    foreach (var item in joinedData)
//    {
//        dto.Add(new ProductDto()
//        {
//            BrandId=item.BrandId,
//            BrandName=item.BrandName,
//            CategoryId=item.CategoryId,
//            CategoryName=item.CategoryName,
//            Id = item.Id,
//            ProducerCode=item.ProducerCode,
//            ProductName = item.ProductName,
//            ProductCode=item.ProductCode,
//            VehicleGroupId=item.VehicleGroupId,
//            VehicleGroupName = item.VehicleGroupName,
//            VehicleTypeId=item.VehicleTypeId,
//            VehicleTypeName = item.VehicleTypeName,
//            CreateDate = item.CreateDate
//        });


//    }
//    return dto;

//}