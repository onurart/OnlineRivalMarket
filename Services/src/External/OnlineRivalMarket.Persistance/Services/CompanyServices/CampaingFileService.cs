﻿namespace OnlineRivalMarket.Persistance.Services.CompanyServices;
public class CampaingFileService : ICampaingFileService
{
    private readonly ICampaingFileCommandRepository _imagesFileCommandRepository;
    private readonly ICampaingFİleQueryRepository _imagesFileQueryRepository;
    private readonly ICompanyDbUnitOfWork _unitOfWork;
    private readonly IContextService _contextService;
    private readonly IMapper _mapper;
    private CompanyDbContext _context;
    public CampaingFileService(ICampaingFileCommandRepository imagesFileCommandRepository, ICampaingFİleQueryRepository imagesFileQueryRepository, ICompanyDbUnitOfWork unitOfWork, IContextService contextService, IMapper mapper)
    {
        _imagesFileCommandRepository = imagesFileCommandRepository;
        _imagesFileQueryRepository = imagesFileQueryRepository;
        _unitOfWork = unitOfWork;
        _contextService = contextService;
        _mapper = mapper;
    }
    public async Task<CampaingImagesFile> CreateAsync(CampaingImagesFile imagesFile, string companyid, CancellationToken cancellationToken)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyid);
        _imagesFileCommandRepository.SetDbContextInstance(_context);
        _unitOfWork.SetDbContextInstance(_context);
        imagesFile.Id = Guid.NewGuid().ToString();
        await _imagesFileCommandRepository.AddAsync(imagesFile, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return imagesFile;
    }
    public IQueryable<CampaingImagesFile> GetAll(string companyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _imagesFileQueryRepository.SetDbContextInstance(_context);
        _unitOfWork.SetDbContextInstance(_context);
        return _imagesFileQueryRepository.GetAll();
    }
    public Task UpdateAsync(CampaingImagesFile ticketFile)
    {
        throw new NotImplementedException();
    }
    public Task RemoveByIdAsync(string id)
    {
        throw new NotImplementedException();
    }
}
