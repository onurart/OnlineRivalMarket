namespace OnlineRivalMarket.Persistance.Services.CompanyServices;
public sealed class CategoryService : ICategoryService
{
    private readonly ICategoryCommandRepository _categoryCommandRepository;
    private readonly ICategoryQueryRepository _categoryQueryRepository;
    private readonly ICompanyDbUnitOfWork _unitOfWork;
    private readonly IContextService _contextService;
    private readonly IRabbitMQService _rabbitMQService;
    private readonly IMapper _mapper;
    private CompanyDbContext _context;
    public CategoryService(ICategoryCommandRepository categoryCommandRepository, ICategoryQueryRepository categoryQueryRepository, ICompanyDbUnitOfWork unitOfWork, IContextService contextService, IMapper mapper, IRabbitMQService rabbitMQService = null)
    {
        _categoryCommandRepository = categoryCommandRepository;
        _categoryQueryRepository = categoryQueryRepository;
        _unitOfWork = unitOfWork;
        _contextService = contextService;
        _mapper = mapper;
        _rabbitMQService = rabbitMQService;
    }
    public async Task<Category> CreateCategoryAsync(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _categoryCommandRepository.SetDbContextInstance(_context);
        _unitOfWork.SetDbContextInstance(_context);
        Category category = _mapper.Map<Category>(request);
        category.Id = Guid.NewGuid().ToString();
        await _categoryCommandRepository.AddAsync(category, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        SendQueue(category, request.CompanyId);

        return category;
    }
    public async Task<IList<Category>> GetAllCategoryAsync(string companyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _categoryQueryRepository.SetDbContextInstance(_context);
        return await _categoryQueryRepository.GetAll().AsNoTracking().ToListAsync();
    }
    public void SendQueue(Category category, string companyId)
    {
        CategoryDto reportDto = new()
        {
            Id = category.Id,
            Name = category.Name,
            CompanyId = companyId
        };

        _rabbitMQService.SendQueue(reportDto);
    }


}

