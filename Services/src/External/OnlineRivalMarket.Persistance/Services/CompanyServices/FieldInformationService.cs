namespace OnlineRivalMarket.Persistance.Services.CompanyServices;
public sealed class FieldInformationService : IFieldInformationService
{
    private readonly IFieldInformationCommandRepository _commandRepository;
    private readonly IFieldInformationQueryRepository _queryRepository;
    private readonly ICompanyDbUnitOfWork _unitOfWork;
    private readonly IContextService _contextService;
    private readonly IMapper _mapper;
    private CompanyDbContext _context;
    public FieldInformationService(IFieldInformationCommandRepository commandRepository, IFieldInformationQueryRepository queryRepository, ICompanyDbUnitOfWork unitOfWork, IContextService contextService, IMapper mapper)
    {
        _commandRepository = commandRepository;
        _queryRepository = queryRepository;
        _unitOfWork = unitOfWork;
        _contextService = contextService;
        _mapper = mapper;
    }
    public async Task<IList<FieldInformationsesDto>> GetAllFieldInfoDtoFilterAsync(string companyId, List<string> competitorIds, DateTime? startDate, DateTime? endDate, string keyword = null)
    {
        var context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(context);
        var query = _queryRepository.GetAll(false)
                                    .Include(pc => pc.Competitor)
                                    .Include(pc => pc.FieldInformationImagesFiles)
                                    .AsQueryable();
        bool isOtherFiltersEmpty = competitorIds?.Count == 0 && string.IsNullOrEmpty(keyword);
        if (!isOtherFiltersEmpty)
        {
            if (competitorIds?.Count > 0)
            {
                query = query.Where(pc => competitorIds.Contains(pc.CompetitorId));
            }
            if (startDate != default && endDate != default)
            {
                endDate = endDate.Value.AddDays(1);
                query = query.Where(pc => pc.CreatedDate >= startDate && pc.CreatedDate <= endDate);
            }
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(pc =>
                    (pc.Description != null && pc.Description.Contains(keyword)) ||
                    (pc.Title != null && pc.Title.Contains(keyword)) ||
                    (pc.Competitor.Name != null && pc.Competitor.Name.Contains(keyword))
                );
            }
        }
        var dtoList = await query.OrderByDescending(pc => pc.CreatedDate)
                                 .Select(pc => new FieldInformationsesDto
                                 {
                                     Id = pc.Id,
                                     CompetitorId = pc.CompetitorId,
                                     CompetitorName = pc.Competitor.Name,
                                     Description = pc.Description,
                                     CreatedDate = pc.CreatedDate,
                                     Title = pc.Title,
                                     RowNo = (int)pc.RowNo,
                                     ImageFiles = pc.FieldInformationImagesFiles.Select(x => x.FieldInformationFileUrls).ToList()
                                 })
                                 .ToListAsync();
        return dtoList;
    }
    public async Task<FieldInformation> CreateFieldInformationAsync(CreateFieldInformationCommand requset, CancellationToken cancellationToken)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(requset.CompanyId);
        _commandRepository.SetDbContextInstance(_context);
        _queryRepository.SetDbContextInstance(_context);
        _unitOfWork.SetDbContextInstance(_context);
        int maxRowNo = await _queryRepository.GetAll(false).MaxAsync(f => (int?)f.RowNo ?? 0);
        FieldInformation record = _mapper.Map<FieldInformation>(requset);
        record.Id = Guid.NewGuid().ToString();
        record.RowNo = maxRowNo + 1;
        await _commandRepository.AddAsync(record, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return record;
    }
    public async Task<IList<FieldInformationsesDto>> GetAllFieldInformationHomeAsync(FieldInformationHomeQuery companyId)
    {
        var context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId.CompandyId);
        _queryRepository.SetDbContextInstance(context);
        var dtoList = await _queryRepository.GetAll()
                                            .Include(x => x.Competitor)
                                            .Include(x => x.FieldInformationImagesFiles)
                                            .OrderByDescending(pc => pc.CreatedDate)
                                            .Select(pc => new FieldInformationsesDto
                                            {
                                                Id = pc.Id,
                                                CompetitorId = pc.CompetitorId,
                                                CompetitorName = pc.Competitor != null ? pc.Competitor.Name : null,
                                                Description = pc.Description,
                                                Title = pc.Title,
                                                CreatedDate = pc.CreatedDate,
                                                ImageFiles = pc.FieldInformationImagesFiles != null ? pc.FieldInformationImagesFiles.Select(x => x.FieldInformationFileUrls) : null,
                                                AppUserId = pc.UserId,
                                                AppUserName = pc.UserLastName,
                                                RowNo = (int)pc.RowNo
                                            })
                                            .Take(6)
                                            .ToListAsync();
        return dtoList;
    }
    public async Task<IList<FieldInformationsesDto>> GetAllFieldInformationDtoAsync(FieldInformationDtoQuery companyId)
    {
        var context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId.CompanyId);
        _queryRepository.SetDbContextInstance(context);

        var joinedData = await _queryRepository.GetAll()
                                               .Include(x => x.Competitor)
                                               .Include(x => x.FieldInformationImagesFiles)
                                               .OrderByDescending(pc => pc.CreatedDate)
                                               .Select(pc => new FieldInformationsesDto
                                               {
                                                   Id = pc.Id,
                                                   CompetitorId = pc.CompetitorId,
                                                   CompetitorName = pc.Competitor != null ? pc.Competitor.Name : null,
                                                   Description = pc.Description,
                                                   Title = pc.Title,
                                                   ImageFiles = pc.FieldInformationImagesFiles != null ? pc.FieldInformationImagesFiles.Select(x => x.FieldInformationFileUrls) : null,
                                                   CreatedDate = pc.CreatedDate,
                                                   AppUserId = pc.UserId,
                                                   AppUserName = pc.UserLastName,
                                                   RowNo = (int)pc.RowNo
                                               })
                                               .ToListAsync();
        return joinedData;
    }
    public async Task<IList<CompetitorIntelligenceRecordDto>> CompetitorIntelligenceRecord(string id, string companyId)
    {
        var context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(context);
        var dtoList = await _queryRepository.GetWhere(x => x.Competitor.Id == id, false)
                                            .Include(x => x.Competitor)
                                            .Select(pc => new CompetitorIntelligenceRecordDto
                                            {
                                                Id = pc.Id,
                                                CompetitorId = pc.CompetitorId,
                                                CompetitorName = pc.Competitor != null ? pc.Competitor.Name : null,
                                                Description = pc.Description,
                                                Title = pc.Description,
                                                RowNo = (int)pc.RowNo,
                                                CreatedDate = pc.CreatedDate,
                                            })
                                            .ToListAsync();
        return dtoList;
    }
    public async Task<IList<FieldInformationsesDto>> GetAllFieldInformationByIdAsync(string id, string companyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);
        var joinedData = await (from pc in _queryRepository.GetWhere(x => x.Id == id).Include(x => x.Competitor).Include(x => x.FieldInformationImagesFiles)
                                join p in _queryRepository.GetAll(false) on pc.Id equals p.Id
                                orderby pc.CreatedDate descending
                                select new FieldInformationsesDto
                                {
                                    Id = pc.Id,
                                    CompetitorId = pc.CompetitorId,
                                    CompetitorName = pc.Competitor != null ? pc.Competitor.Name : null,
                                    Description = pc.Description,
                                    Title = pc.Title,
                                    ImageFiles = pc.FieldInformationImagesFiles != null ? pc.FieldInformationImagesFiles.Select(x => x.FieldInformationFileUrls) : null,
                                    CreatedDate = pc.CreatedDate,
                                    AppUserId = pc.UserId,
                                    RowNo = (int)pc.RowNo,
                                    AppUserName = pc.UserLastName,
                                }).ToListAsync();
        return joinedData;
    }
    public async Task<IList<FieldInformation>> GetAllFieldInformationAsync(string companyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);
        return await _queryRepository.GetAll().AsNoTracking().Select(p => new FieldInformation { Id = p.Id, Title = p.Title }).ToListAsync();
    }
}