using OnlineRivalMarket.Application.Services.CompanyServices;
using OnlineRivalMarket.Domain;
using OnlineRivalMarket.Domain.Dtos.ForeignCurrency;
namespace OnlineRivalMarket.Persistance.Services.CompanyServices
{
    public class ForeignCurrencyService : IForeignCurrencyService
    {
        private readonly IForeignCurrencyCommandRepository _commandRepository;
        private readonly IForeignCurrencyQueryRepository _queryRepository;
        private readonly ICompanyDbUnitOfWork _unitOfWork;
        private readonly IContextService _contextService;
        private readonly IMapper _mapper;
        private CompanyDbContext _context;

        public ForeignCurrencyService(IForeignCurrencyCommandRepository commandRepository, IForeignCurrencyQueryRepository queryRepository, ICompanyDbUnitOfWork unitOfWork, IContextService contextService, IMapper mapper)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
            _unitOfWork = unitOfWork;
            _contextService = contextService;
            _mapper = mapper;
        }

        public async Task<ForeignCurrency> CreateForeignCurrencyAsync(CreateForeignCurrencyCommand request, CancellationToken cancellationToken)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
            _commandRepository.SetDbContextInstance(_context);
            _unitOfWork.SetDbContextInstance(_context);
            ForeignCurrency currency = _mapper.Map<ForeignCurrency>(request);
            currency.Id=Guid.NewGuid().ToString();
            await _commandRepository.AddAsync(currency, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return currency;
        }

        public async Task<IList<ForeignCurrency>> GetAllForeignCurrencyAsync(string companyıd)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyıd);
            _queryRepository.SetDbContextInstance(_context); 
            return await _queryRepository.GetAll().AsNoTracking().ToListAsync();
        }
        
        
        public async Task<IList<ForeignCurrencyDto>> GetAllForeignCurrencyDtoAsync(string companyıd)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyıd);
            _queryRepository.SetDbContextInstance(_context); 
            return await _queryRepository
                        .GetAll()
                        .AsNoTracking()
                        .Select(P=> new ForeignCurrencyDto { Id=P.Id, CurrencyName=P.CurrencyName})
                        .ToListAsync();
        }
    }
}
