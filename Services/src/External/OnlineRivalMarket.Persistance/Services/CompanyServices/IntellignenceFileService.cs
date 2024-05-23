using OnlineRivalMarket.Application.Services.CompanyServices;
using OnlineRivalMarket.Domain;
namespace OnlineRivalMarket.Persistance.Services.CompanyServices;
public sealed class IntellignenceFileService : IIntellignenceFileService
{
    private readonly IImagesFileCommandRepository _imagesFileCommandRepository;
    private readonly IImagesFileQueryRepository _imagesFileQueryRepository;
    private readonly ICompanyDbUnitOfWork _unitOfWork;
    private readonly IContextService _contextService;
    private readonly IMapper _mapper;
    private CompanyDbContext _context;
    public IntellignenceFileService(IImagesFileCommandRepository imagesFileCommandRepository, IImagesFileQueryRepository imagesFileQueryRepository, ICompanyDbUnitOfWork unitOfWork, IContextService contextService = null, IMapper mapper = null)
    {
        _imagesFileCommandRepository = imagesFileCommandRepository;
        _imagesFileQueryRepository = imagesFileQueryRepository;
        _unitOfWork = unitOfWork;
        _contextService = contextService;
        _mapper = mapper;
    }

    public async Task<ImagesFile> CreateAsync(ImagesFile imagesFile,string companyid, CancellationToken cancellationToken)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyid);
        _imagesFileCommandRepository.SetDbContextInstance(_context);
        _unitOfWork.SetDbContextInstance(_context);
        imagesFile.Id = Guid.NewGuid().ToString();
        await _imagesFileCommandRepository.AddAsync(imagesFile, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return imagesFile;
    }

    public IQueryable<ImagesFile> GetAll(string companyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _imagesFileQueryRepository.SetDbContextInstance(_context);
        _unitOfWork.SetDbContextInstance(_context);
        return _imagesFileQueryRepository.GetAll();
    }

    public async Task UpdateAsync(ImagesFile ticketFile)
    {
        _imagesFileCommandRepository.Update(ticketFile);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task RemoveByIdAsync(string id)
    {
        await _imagesFileCommandRepository.RemoveById(id);
        await _unitOfWork.SaveChangesAsync();
    }


}
