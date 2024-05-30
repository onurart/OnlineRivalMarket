namespace OnlineRivalMarket.Persistance.Services.CompanyServices;
public sealed class ProductService : IProductService
{
    private readonly IProductCommandRepository _commandRepository;
    private readonly IProductQueryRepository _queryRepository;
    private readonly IContextService _contextService;
    private readonly ICompanyDbUnitOfWork _companyDbUnitOfWork;
    private readonly IMapper _mapper;
    private CompanyDbContext _context;
    public ProductService(IProductCommandRepository commandRepository, IProductQueryRepository queryRepository, IContextService contextService, ICompanyDbUnitOfWork companyDbUnitOfWork, IMapper mapper)
    {
        _commandRepository = commandRepository;
        _queryRepository = queryRepository;
        _contextService = contextService;
        _companyDbUnitOfWork = companyDbUnitOfWork;
        _mapper = mapper;
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
        var query = _queryRepository.GetAll(false)
            .Include(pc => pc.VehicleType)
            .Include(pc => pc.VehicleGrup)
            .Include(pc => pc.Category)
            .Include(pc => pc.Brand);
        PaginationResult<ProductDto> paginationResult = await query.Select(pc => new ProductDto
        {
            Id = pc.Id,
            ProducerCode = pc.ProducerCode,
            ProductName = pc.ProductName,
            ProductCode = pc.ProductCode,
            VehicleTypeId = pc.VehicleTypeId,
            VehicleTypeName = pc.VehicleType.Name,
            VehicleGroupId = pc.VehicleGroupId,
            VehicleGroupName = pc.VehicleGrup.Name,
            BrandId = pc.BrandId,
            BrandName = pc.Brand.Name,
            CategoryId = pc.CategoryId,
            CategoryName = pc.Category.Name,
        })
        .ToPagedListAsync(request.PageSize, request.PageNumber);
        return paginationResult;
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
    public async Task<IList<ProductDto>> GetAllProduct(string companyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);
        var productQuery = _queryRepository.GetAll(false)
            .Include(p => p.VehicleType)
            .Include(p => p.VehicleGrup)
            .Include(p => p.Brand)
            .Include(p => p.Category)
            .AsQueryable();
        var products = await productQuery.ToListAsync();
        var productDtos = products.Select(p => new ProductDto
        {
            Id = p.Id,
            CreateDate = p.CreatedDate,
            ProducerCode = p.ProducerCode,
            ProductCode = p.ProductCode,
            BrandId = p.BrandId,
            BrandName = p.Brand?.Name,
            CategoryId = p.CategoryId,
            CategoryName = p.Category?.Name,
            ProductName = p.ProductName,
            VehicleGroupId = p.VehicleGrup?.Id,
            VehicleGroupName = p.VehicleGrup?.Name,
            VehicleTypeId = p.VehicleType?.Id,
            VehicleTypeName = p.VehicleType?.Name
        }).OrderByDescending(p => p.CreateDate).ToList();
        return productDtos;
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