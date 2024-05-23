using OnlineRivalMarket.Application.Services.CompanyServices;
using OnlineRivalMarket.Domain;
namespace OnlineRivalMarket.Persistance.Services.CompanyServices
{
    public class CFFFiileService : ICFFieldFileService
    {
        private readonly ICFFileCommandRepository _cfFileCommandRepository;
        private readonly ICFQueryRepository _cfFileQueryRepository;
        private readonly ICompanyDbUnitOfWork _companyDbUnitOfWork;
        private readonly IContextService _contextService;
        private readonly IMapper _mapper;
        private CompanyDbContext _context;
        public CFFFiileService(ICFFileCommandRepository cfFileCommandRepository, ICFQueryRepository cfFileQueryRepository, ICompanyDbUnitOfWork companyDbUnitOfWork, IContextService contextService, IMapper mapper)
        {
            _cfFileCommandRepository = cfFileCommandRepository;
            _cfFileQueryRepository = cfFileQueryRepository;
            _companyDbUnitOfWork = companyDbUnitOfWork;
            _contextService = contextService;
            _mapper = mapper;
        }
        public async Task<FieldInformationImagesFile> CreateAsync(FieldInformationImagesFile imagesFile, string companyid, CancellationToken cancellationToken)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyid);
            _cfFileCommandRepository.SetDbContextInstance(_context);
            _companyDbUnitOfWork.SetDbContextInstance(_context);
            imagesFile.Id = Guid.NewGuid().ToString();
            await _cfFileCommandRepository.AddAsync(imagesFile, cancellationToken);
            await _companyDbUnitOfWork.SaveChangesAsync(cancellationToken);
            return imagesFile;
        }
        public IQueryable<FieldInformationImagesFile> GetAll(string companyId)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
            _cfFileQueryRepository.SetDbContextInstance(_context);
            _companyDbUnitOfWork.SetDbContextInstance(_context);
            return _cfFileQueryRepository.GetAll();
        }
        public Task RemoveByIdAsync(string id)
        {
            throw new NotImplementedException();
        }
        public Task UpdateAsync(FieldInformationImagesFile ticketFile)
        {
            throw new NotImplementedException();
        }
    }
}
