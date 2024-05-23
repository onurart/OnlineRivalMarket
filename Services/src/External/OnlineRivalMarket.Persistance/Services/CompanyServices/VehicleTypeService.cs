using OnlineRivalMarket.Application.Services.CompanyServices;
using OnlineRivalMarket.Domain;
namespace OnlineRivalMarket.Persistance.Services.CompanyServices
{
    public sealed class VehicleTypeService : IVehicleTypeService
    {
        private readonly IVehicleTypeCommandRepository _vehicleTypeCommandRepository;
        private readonly IVehicleTypeQuertRepository _vehicleTypeQueryRepository;
        private readonly ICompanyDbUnitOfWork _unitOfWork;
        private readonly IContextService _contextService;
        private readonly IMapper _mapper;
        private CompanyDbContext _context;
        public VehicleTypeService(IVehicleTypeCommandRepository vehicleTypeCommandRepository, IVehicleTypeQuertRepository vehicleTypeQueryRepository, ICompanyDbUnitOfWork unitOfWork, IContextService contextService, IMapper mapper)
        {
            _vehicleTypeCommandRepository = vehicleTypeCommandRepository;
            _vehicleTypeQueryRepository = vehicleTypeQueryRepository;
            _unitOfWork = unitOfWork;
            _contextService = contextService;
            _mapper = mapper;
        }
        public async Task<VehicleType> CreateVehicleTypeAsync(CreateVehicleTypeCommand requst, CancellationToken cancellationToken)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(requst.companyId);
            _vehicleTypeCommandRepository.SetDbContextInstance(_context);
            _unitOfWork.SetDbContextInstance(_context);
            VehicleType vehicleType = _mapper.Map<VehicleType>(requst);
            vehicleType.Id = Guid.NewGuid().ToString();
            await _vehicleTypeCommandRepository.AddAsync(vehicleType, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return vehicleType;
        }
        public async Task<IList<VehicleType>> GetAllVehicleTypeAsync(string companyId)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
            _vehicleTypeQueryRepository.SetDbContextInstance(_context);
            return await _vehicleTypeQueryRepository.GetAll().AsNoTracking().ToListAsync();
        }
    }
}
