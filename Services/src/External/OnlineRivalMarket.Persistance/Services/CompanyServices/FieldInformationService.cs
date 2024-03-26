    using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineRivalMarket.Application.Features.CompanyFeatures.FieldInformationFeatures.Commands;
using OnlineRivalMarket.Application.Services.CompanyServices;
using OnlineRivalMarket.Domain;
using OnlineRivalMarket.Domain.CompanyEntities;
using OnlineRivalMarket.Domain.Repositories.CompanyDbContext.FieldInformationRepository;
using OnlineRivalMarket.Domain.UnitOfWorks;
using OnlineRivalMarket.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRivalMarket.Persistance.Services.CompanyServices
{
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

        public async Task<FieldInformation> CreateFieldInformationAsync(CreateFieldInformationCommand requset, CancellationToken cancellationToken)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(requset.companyId);
            _commandRepository.SetDbContextInstance(_context);
            _unitOfWork.SetDbContextInstance(_context);
            FieldInformation fieldInformation = _mapper.Map<FieldInformation>(requset);
            fieldInformation.Id = Guid.NewGuid().ToString();
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return fieldInformation;
        }

        public async Task<IList<FieldInformation>> GetAllFieldInformationAsync(string companyId)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId); ;
            _queryRepository.SetDbContextInstance(_context);
            return await _queryRepository.GetAll().AsNoTracking().ToListAsync();
        }
    }
}
