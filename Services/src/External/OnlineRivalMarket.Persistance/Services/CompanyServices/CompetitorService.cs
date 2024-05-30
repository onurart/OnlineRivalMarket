namespace OnlineRivalMarket.Persistance.Services.CompanyServices;
public class CompetitorService : ICompetitorService
{
    private readonly ICompetitorCommandRepository _commandRepository;
    private readonly ICompetitorQueryRepository _queryRepository;
    private readonly ICompanyDbUnitOfWork _unitOfWork;
    private readonly IContextService _contextService;
    private readonly IMapper _mapper;
    private CompanyDbContext _context;
    public CompetitorService(ICompetitorCommandRepository commandRepository, ICompetitorQueryRepository queryRepository, IContextService contextService, ICompanyDbUnitOfWork unitOfWork, IMapper mapper)
    {
        _commandRepository = commandRepository;
        _queryRepository = queryRepository;
        _contextService = contextService;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<Competitor> CreateCompetitorsAsync(CreateCompetitorsCommand requset, CancellationToken cancellationToken)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(requset.companyId);
        _commandRepository.SetDbContextInstance(_context);
        _unitOfWork.SetDbContextInstance(_context);
        Competitor competitorses = _mapper.Map<Competitor>(requset);
        competitorses.Id = Guid.NewGuid().ToString();
        await _commandRepository.AddAsync(competitorses, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return competitorses;
    }
    public async Task<IList<Competitor>> GetAllCompetitorsAsync(string companyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);
        return await _queryRepository.GetAll().AsNoTracking().ToListAsync();
    }
}
