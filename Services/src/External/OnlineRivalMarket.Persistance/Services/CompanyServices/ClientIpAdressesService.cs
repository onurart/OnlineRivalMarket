namespace OnlineRivalMarket.Persistance.Services.CompanyServices;
public class ClientIpAdressesService : IClientIpAddressesService
{
    private readonly IIpAddressesCommandRepository _commandRepository;
    private readonly IIpAddressQueryRepository _ipAddressQueryRepository;
    private readonly ICompanyDbUnitOfWork _companyDbUnitOfWork;
    private readonly IContextService _contextService;
    private readonly IMapper _mapper;
    private CompanyDbContext _context;
    public ClientIpAdressesService(IIpAddressesCommandRepository commandRepository, IIpAddressQueryRepository ipAddressQueryRepository, ICompanyDbUnitOfWork companyDbUnitOfWork, IContextService contextService, IMapper mapper)
    {
        _commandRepository = commandRepository;
        _ipAddressQueryRepository = ipAddressQueryRepository;
        _companyDbUnitOfWork = companyDbUnitOfWork;
        _contextService = contextService;
        _mapper = mapper;
    }
    public async Task<ClientIpAddresses> CreateIpAddresAsync(CreateClientIpAddressCommand request, CancellationToken cancellationToken)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _commandRepository.SetDbContextInstance(_context);
        _companyDbUnitOfWork.SetDbContextInstance(_context);
        ClientIpAddresses clientIpAddresses = _mapper.Map<ClientIpAddresses>(request);
        clientIpAddresses.Id = Guid.NewGuid().ToString();
        await _commandRepository.AddAsync(clientIpAddresses, cancellationToken);
        await _companyDbUnitOfWork.SaveChangesAsync(cancellationToken);
        return clientIpAddresses;
    }
    public async Task<ClientIpAddresses> GetByIdAsync(DateTime? UpdatedDate, string id, string companyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _commandRepository.SetDbContextInstance(_context);
        _companyDbUnitOfWork.SetDbContextInstance(_context);
        _ipAddressQueryRepository.SetDbContextInstance(_context);
        ClientIpAddresses product = await _ipAddressQueryRepository.GetById(id);
        product.UpdatedDate = UpdatedDate;
        _commandRepository.Update(product);
        await _companyDbUnitOfWork.SaveChangesAsync();
        return product;
    }
    public async Task<IList<ClientIpAddresses>> GetAllIpAddres(string companyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _ipAddressQueryRepository.SetDbContextInstance(_context);
        return await _ipAddressQueryRepository.GetAll().AsNoTracking().ToListAsync();
    }
}
