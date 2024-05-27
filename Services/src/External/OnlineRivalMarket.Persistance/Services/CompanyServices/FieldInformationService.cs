using OnlineRivalMarket.Application.Features.CompanyFeatures.FieldInformationFeatures.Queries.FieldInformationDto;
using OnlineRivalMarket.Application.Features.CompanyFeatures.FieldInformationFeatures.Queries.FieldInformationHome;
using OnlineRivalMarket.Application.Services.CompanyServices;
using OnlineRivalMarket.Domain;
using OnlineRivalMarket.Domain.Dtos.Campaing;
using OnlineRivalMarket.Domain.Dtos.FieldInformationDtos;
namespace OnlineRivalMarket.Persistance.Services.CompanyServices
{
    public sealed class FieldInformationService : IFieldInformationService
    {
        private readonly IFieldInformationCommandRepository _commandRepository;
        private readonly IFieldInformationQueryRepository _queryRepository;
        private readonly ICompanyDbUnitOfWork _unitOfWork;
        private readonly IContextService _contextService;
        private readonly ICompetitorQueryRepository _competitorQueryRepository;
        private readonly IMapper _mapper;
        private CompanyDbContext _context;
        public FieldInformationService(IFieldInformationCommandRepository commandRepository, IFieldInformationQueryRepository queryRepository, ICompanyDbUnitOfWork unitOfWork, IContextService contextService, IMapper mapper, ICompetitorQueryRepository competitorQueryRepository = null)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
            _unitOfWork = unitOfWork;
            _contextService = contextService;
            _mapper = mapper;
            _competitorQueryRepository = competitorQueryRepository;
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
        public async Task<IList<FieldInformation>> GetAllFieldInformationAsync(string companyId)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
            _queryRepository.SetDbContextInstance(_context);
            return await _queryRepository.GetAll().AsNoTracking().Select(p => new FieldInformation { Id = p.Id, Title = p.Title }).ToListAsync();
        }
        public async Task<IList<FieldInformationsesDto>> GetAllFieldInformationHomeAsync(FieldInformationHomeQuery companyId)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId.CompandyId);
            _queryRepository.SetDbContextInstance(_context);
            await _queryRepository.GetAll().AsNoTracking().ToListAsync();

            var prodcustrel = await _queryRepository.GetAll().Include("Competitor").Include(x => x.FieldInformationImagesFiles).ToListAsync();
            var product = await _queryRepository.GetAll().ToListAsync();
            var joinedData = (from pc in prodcustrel
                              join p in product on pc.Id equals p.Id
                              orderby pc.CreatedDate descending
                              select new FieldInformationsesDto
                              {
                                  Id = pc.Id,
                                  CompetitorId = pc.CompetitorId,
                                  CompetitorName = p.Competitor.Name,
                                  Description = pc.Description,
                                  Title = pc.Title,
                                  CreatedDate = pc.CreatedDate,
                                  ImageFiles = pc.FieldInformationImagesFiles.Select(x => x.FieldInformationFileUrls),
                                  AppUserId = pc.UserId,
                                  AppUserName = pc.UserLastName,
                                  RowNo=(int)pc.RowNo,  

                              }).Take(6).ToList();
            List<FieldInformationsesDto> dto = new List<FieldInformationsesDto>();
            foreach (var item in joinedData)
            {
                dto.Add(new FieldInformationsesDto()
                {
                    Id = item.Id,
                    Title = item.Title,
                    Description = item.Description,
                    CompetitorId = item.CompetitorId,
                    CompetitorName = item.CompetitorName,
                    CreatedDate = item.CreatedDate,
                    ImageFiles = item.ImageFiles,
                    AppUserId = item.AppUserId,
                    RowNo=item.RowNo,
                    AppUserName = item.AppUserName
                });


            }
            return dto;
        }
        public async Task<IList<FieldInformationsesDto>> GetAllFieldInformationDtoAsync(FieldInformationDtoQuery companyId)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId.CompanyId);
            _queryRepository.SetDbContextInstance(_context);
            await _queryRepository.GetAll().AsNoTracking().ToListAsync();
            var prodcustrel = await _queryRepository.GetAll().Include("Competitor").Include(x => x.FieldInformationImagesFiles).ToListAsync();
            var product = await _queryRepository.GetAll().ToListAsync();
            var joinedData = (from pc in prodcustrel
                              join p in product on pc.Id equals p.Id
                              orderby pc.CreatedDate descending
                              select new FieldInformationsesDto
                              {
                                  Id = pc.Id,
                                  CompetitorId = pc.CompetitorId,
                                  CompetitorName = pc.Competitor.Name,
                                  Description = pc.Description,
                                  Title = pc.Title,
                                  ImageFiles = pc.FieldInformationImagesFiles.Select(x => x.FieldInformationFileUrls),
                                  CreatedDate = pc.CreatedDate,
                                  AppUserId = pc.UserId,
                                  AppUserName = pc.UserLastName,
                                  RowNo = (int)pc.RowNo
                              }).ToList();
            List<FieldInformationsesDto> dto = new List<FieldInformationsesDto>();
            foreach (var item in joinedData)
            {
                dto.Add(new FieldInformationsesDto()
                {
                    Id = item.Id,
                    Title = item.Title,
                    Description = item.Description,
                    CompetitorId = item.CompetitorId,
                    CompetitorName = item.CompetitorName,
                    CreatedDate = item.CreatedDate,
                    ImageFiles = item.ImageFiles,
                    AppUserName = item.AppUserName,
                    AppUserId = item.AppUserId,
                    RowNo= (int)item.RowNo

                });}
            return dto;
        }
        public async Task<IList<FieldInformationsesDto>> GetAllFieldInformationByIdAsync(string id, string companyId)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
            _queryRepository.SetDbContextInstance(_context);
            var prodcustrel = await _queryRepository.GetWhere(x => x.Id == id).Include("Competitor").Include(x => x.FieldInformationImagesFiles).ToListAsync();
            var product = await _queryRepository.GetAll().ToListAsync();
            var joinedData = (from pc in prodcustrel
                              join p in product on pc.Id equals p.Id
                              orderby pc.CreatedDate descending
                              select new FieldInformationsesDto
                              {
                                  Id = pc.Id,
                                  CompetitorId = pc.CompetitorId,
                                  CompetitorName = pc.Competitor.Name,
                                  Description = pc.Description,
                                  Title = pc.Title,
                                  ImageFiles = pc.FieldInformationImagesFiles.Select(x => x.FieldInformationFileUrls),
                                  CreatedDate = pc.CreatedDate,
                                  AppUserId = pc.UserId,
                                  RowNo=(int)pc.RowNo,
                                  AppUserName = pc.UserLastName,

                              }).ToList();
            List<FieldInformationsesDto> dto = new List<FieldInformationsesDto>();
            foreach (var item in joinedData)
            {
                dto.Add(new FieldInformationsesDto()
                {
                    Id = item.Id,
                    Title = item.Title,
                    Description = item.Description,
                    CompetitorId = item.CompetitorId,
                    CompetitorName = item.CompetitorName,
                    ImageFiles = item.ImageFiles,
                    CreatedDate = item.CreatedDate,
                    AppUserId = item.AppUserId,
                    RowNo=(int)item.RowNo,
                    AppUserName = item.AppUserName

                });


            }
            return dto;

        }
        public async Task<IList<FieldInformationsesDto>> GetAllFieldInfoDtoFilterAsync(string companyId, List<string> competitorIds, DateTime? startDate, DateTime? endDate, string keyword = null)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
            _queryRepository.SetDbContextInstance(_context);
            var prodcustrelQuery = _queryRepository.GetAll(false)
                                    .Include(pc => pc.Competitor)
                                    .Include(pc => pc.FieldInformationImagesFiles)
                                    .AsQueryable();
            // Tarih aralığı ve keyword dışında diğer filtrelerin boş olup olmadığını kontrol et
            bool isOtherFiltersEmpty = !competitorIds?.Any() == true && string.IsNullOrEmpty(keyword);


            if (startDate != default && endDate != default && isOtherFiltersEmpty)
            {
                prodcustrelQuery = prodcustrelQuery.Where(pc => pc.CreatedDate >= startDate && pc.CreatedDate <= endDate.Value.AddDays(1));
            }
            else
            {
                if (competitorIds?.Any() == true)
                {
                    prodcustrelQuery = prodcustrelQuery.Where(pc => competitorIds.Contains(pc.CompetitorId));
                }
                if (startDate != default && endDate != default)
                {
                    prodcustrelQuery = prodcustrelQuery.Where(pc => pc.CreatedDate >= startDate && pc.CreatedDate <= endDate.Value.AddDays(1));
                }
                if (!string.IsNullOrEmpty(keyword))
                {
                    prodcustrelQuery = prodcustrelQuery.Where(pc =>
                        (pc.Description != null && pc.Description.Contains(keyword)) ||
                        (pc.Title != null && pc.Title.Contains(keyword)) ||
                        (pc.Competitor.Name != null && pc.Competitor.Name.Contains(keyword))
                    );
                }
            }

            var products = await prodcustrelQuery.ToListAsync();
            var dtoList = products.Select(pc => new FieldInformationsesDto
            {
                Id = pc.Id,
                CompetitorId = pc.CompetitorId,
                CompetitorName = pc.Competitor.Name,
                Description = pc.Description,
                CreatedDate = pc.CreatedDate,
                Title = pc.Title,
                RowNo= (int)pc.RowNo,
                ImageFiles = pc.FieldInformationImagesFiles.Select(x => x.FieldInformationFileUrls).ToList()
            }).ToList();

            return dtoList;
        }
        public async Task<IList<CompetitorIntelligenceRecordDto>> CompetitorIntelligenceRecord(string id, string companyId) 
        {
            var context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
            _queryRepository.SetDbContextInstance(context);
            var fields = await _queryRepository.GetWhere(x => x.Competitor.Id == id, false)
                .Include(x => x.Competitor)
                .ToListAsync();
            var dtoList = fields.Select(pc => new CompetitorIntelligenceRecordDto
            {
                Id = pc.Id,
                CompetitorId = pc.CompetitorId,
                CompetitorName = pc.Competitor?.Name,
                Description = pc.Description,
                Title = pc.Description,
                RowNo=(int)pc.RowNo,
                CreatedDate = pc.CreatedDate,
            }).ToList();

            return dtoList;
        }




    }
    //public async Task<IList<FieldInformationsesDto>> GetAllFieldInfoDtoFilterAsync(
    //    string companyId,
    //    List<string> competitorIds,
    //    DateTime? startDate,
    //    DateTime? endDate,
    //    string keyword = null)
    //{
    //    _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
    //    _queryRepository.SetDbContextInstance(_context);
    //    var prodcustrelQuery = _queryRepository.GetAll(false)
    //                            .Include(pc => pc.Competitor)
    //                            .Include(pc => pc.FieldInformationImagesFiles)
    //                            .AsQueryable();

    //    // Eğer başlangıç ve bitiş tarihleri belirtilmişse, ona göre arama yap
    //    if (startDate.HasValue && endDate.HasValue)
    //    {
    //        prodcustrelQuery = prodcustrelQuery.Where(pc => pc.CreatedDate >= startDate.Value && pc.CreatedDate < endDate.Value.AddDays(1));
    //    }

    //    // Keyword ve competitorIds filtrelemesi
    //    if (!string.IsNullOrEmpty(keyword))
    //    {
    //        prodcustrelQuery = prodcustrelQuery.Where(pc =>
    //            pc.Description.Contains(keyword) ||
    //            pc.Title.Contains(keyword) ||
    //            (competitorIds != null && competitorIds.Any(id => pc.CompetitorId.Contains(id))));
    //    }

    //    var products = await prodcustrelQuery.ToListAsync();

    //    var dtoList = products.Select(pc => new FieldInformationsesDto
    //    {
    //        Id = pc.Id,
    //        CompetitorId = pc.CompetitorId,
    //        CompetitorName = pc.Competitor.Name,
    //        Description = pc.Description,
    //        CreatedDate = pc.CreatedDate,
    //        Title = pc.Title,
    //        ImageFiles = pc.FieldInformationImagesFiles.Select(x => x.FieldInformationFileUrls).ToList()
    //    }).ToList();

    //    return dtoList;
    //}




    //public Task<IList<FieldInformationsesDto>> GetAllFieldInfoDtoFilterAsync(string companyId, List<string> competitorId, List<string> brandId, List<string> categoryId, DateTime startdate, DateTime enddate)
    //{
    //    throw new NotImplementedException();
    //}

    //public async Task<IList<FieldInformationsesDto>> GetAllFieldInformationByIdAsync(string id, string companyId)
    //{
    //    _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
    //    _queryRepository.SetDbContextInstance(_context);
    //    _queryProductRepository.SetDbContextInstance(_context);
    //    var intelligence = await _queryRepository.GetWhere(x => x.Id == id, false).Include("Competitor").Include(x=>x.).ToListAsync();
    //    var product = await _queryProductRepository.GetAll().Include("VehicleType").Include("VehicleGrup").Include("Brand").Include("Category").ToListAsync();
    //    var joinedData = (from pc in intelligence
    //                      join p in product on pc.ProductId equals p.Id
    //                      orderby pc.CreatedDate descending
    //                      select new IntelligenceByIdDto
    //                      {
    //                          Id = pc.Id,
    //                          CompetitorId = pc.CompetitorId,
    //                          CompetitorName = pc.Competitor != null ? pc.Competitor.Name : null,
    //                          BrandId = p.BrandId,
    //                          BrandName = p.Brand.Name,
    //                          CategoryId = p.CategoryId,
    //                          CategoryName = p.Category.Name,
    //                          ProductId = p.Id,
    //                          ProductName = p.ProductName,
    //                          Description = pc.Description,
    //                          VehicleGroupId = p.VehicleGrup.Id,
    //                          VehicleGroupName = p.VehicleGrup.Name,
    //                          VehicleTypeId = p.VehicleType.Id,
    //                          VehicleTypeName = p.VehicleType.Name,
    //                          MCurrency = pc.MCurrency,
    //                          RakipCurrency = pc.RakipCurrency,
    //                          ForeignCurrencyId = pc.ForeignCurrencyId,
    //                          ForeignCurrencyName = pc.ForeignCurrency.CurrencyName,
    //                          ImageFiles = pc.IntelligenceRecordFiles.Select(x => x.FileUrls)
    //                      }).Take(5).ToList();
    //    List<FieldInformationsesDto> dtos = new List<FieldInformationsesDto>();
    //    foreach (var d in joinedData)
    //    {
    //        dtos.Add(new FieldInformationsesDto()
    //        {
    //            ImageFiles = d.ImageFiles,
    //            CompetitorId=d.CompetitorId,
    //            CompetitorName=d.CompetitorName,
    //            Description = d.Description,    
    //            Title = d.Title,
    //            CreatedDate = d.CreatedDate,    
    //            Id=id,
    //        });
    //    }
    //    return dtos;
    //}
}

