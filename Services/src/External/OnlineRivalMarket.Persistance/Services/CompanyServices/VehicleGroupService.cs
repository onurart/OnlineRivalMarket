namespace OnlineRivalMarket.Persistance.Services.CompanyServices;
public sealed class VehicleGroupService : IVehicleGroupService
{
    private readonly IVehicleGroupCommandRepository _vehicleGroupCommandRepository;
    private readonly IVehicleGroupQueryRepository _vehicleGroupQueryRepository;
    private readonly ICompanyDbUnitOfWork _unitOfWork;
    private readonly IContextService _contextService;
    private readonly IMapper _mapper;
    private CompanyDbContext _context;
    public VehicleGroupService(IVehicleGroupCommandRepository vehicleGroupCommandRepository, IVehicleGroupQueryRepository vehicleGroupQueryRepository, ICompanyDbUnitOfWork unitOfWork, IContextService contextService, IMapper mapper)
    {
        _vehicleGroupCommandRepository = vehicleGroupCommandRepository;
        _vehicleGroupQueryRepository = vehicleGroupQueryRepository;
        _unitOfWork = unitOfWork;
        _contextService = contextService;
        _mapper = mapper;
    }
    public async Task<VehicleGroup> CreateVehicleGroupAsync(CreateVehicleGroupCommand request, CancellationToken cancellationToken)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _vehicleGroupCommandRepository.SetDbContextInstance(_context);
        _unitOfWork.SetDbContextInstance(_context);
        VehicleGroup vehicleGroup  = _mapper.Map<VehicleGroup>(request);
        vehicleGroup.Id = Guid.NewGuid().ToString();
        await _vehicleGroupCommandRepository.AddAsync(vehicleGroup,cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);   
        return vehicleGroup;
    }
    public async Task<IList<VehicleGroup>> GetAllVehicleGroupAsync(string CompanyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(CompanyId);
        _vehicleGroupQueryRepository.SetDbContextInstance(_context);
        return await _vehicleGroupQueryRepository.GetAll().AsNoTracking().ToListAsync();
    }

}
