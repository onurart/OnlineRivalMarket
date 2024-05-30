namespace OnlineRivalMarket.Persistance.Services.CompanyServices;
public sealed class BrandService : IBrandService
{
    private readonly IBrandCommandRepository _commandRepository;
    private readonly IBrandQueryRepository _queryRepository;
    private readonly ICompanyDbUnitOfWork _companyDbUnitOfWork;
    private readonly IContextService _contextService;
    private readonly IMapper _mapper;
    private CompanyDbContext _context;
    public BrandService(IBrandCommandRepository commandRepository, IBrandQueryRepository queryRepository, ICompanyDbUnitOfWork companyDbUnitOfWork, IContextService contextService, IMapper mapper)
    {
        _commandRepository = commandRepository;
        _queryRepository = queryRepository;
        _companyDbUnitOfWork = companyDbUnitOfWork;
        _contextService = contextService;
        _mapper = mapper;
    }
    public async Task<Brand> CreateBrandAsync(CreateBrandCommand requset, CancellationToken cancellationToken)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(requset.CompanyId);
        _commandRepository.SetDbContextInstance(_context); 
        _companyDbUnitOfWork.SetDbContextInstance(_context);
        Brand brand =_mapper.Map<Brand>(requset);
        brand.Id = Guid.NewGuid().ToString();
        await _commandRepository.AddAsync(brand, cancellationToken);
        await _companyDbUnitOfWork.SaveChangesAsync(cancellationToken);
        return brand;
    }
    public async Task<IList<Brand>> GetAllBrandsAsync(string companyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);
        return await _queryRepository.GetAll().AsNoTracking().ToListAsync();
    }
}
