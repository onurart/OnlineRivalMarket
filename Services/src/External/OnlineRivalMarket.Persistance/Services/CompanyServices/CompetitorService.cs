﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineRivalMarket.Application.Features.CompanyFeatures.CompetitorsFeatures.Command.CreateCompetitors;
using OnlineRivalMarket.Application.Services.CompanyServices;
using OnlineRivalMarket.Domain;
using OnlineRivalMarket.Domain.CompanyEntities;
using OnlineRivalMarket.Domain.Repositories.CompanyDbContext.CompetitorRepository;
using OnlineRivalMarket.Domain.UnitOfWorks;
using OnlineRivalMarket.Persistance.Context;

namespace OnlineRivalMarket.Persistance.Services.CompanyServices
{
    public class CompetitorService : ICompetitorService
    {
        private readonly ICompetitorCommandRepository _commandRepository;
        private readonly ICompetitorQueryRepository _queryRepository;
        private readonly ICompanyDbUnitOfWork _unitOfWork;
        private readonly IContextService _contextService;
        private readonly IMapper _mapper;
        private CompanyDbContext _context;


        public CompetitorService(ICompetitorCommandRepository commandRepository, ICompetitorQueryRepository queryRepository, IContextService contextService, ICompanyDbUnitOfWork unitOfWork, IMapper mapper)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
            _contextService = contextService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OnlineRivalMarket.Domain.CompanyEntities.Competitorses> CreateCompetitorsAsync(CreateCompetitorsCommand requset, CancellationToken cancellationToken)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(requset.companyId);
            _commandRepository.SetDbContextInstance(_context);
            _unitOfWork.SetDbContextInstance(_context);
            OnlineRivalMarket.Domain.CompanyEntities.Competitorses competitorses = _mapper.Map<OnlineRivalMarket.Domain.CompanyEntities.Competitorses>(requset);
            competitorses.Id = Guid.NewGuid().ToString();
            await _commandRepository.AddAsync(competitorses, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return competitorses;
        }

        public async Task<IList<Competitorses>> GetAllCompetitorsAsync(string companyId)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
            _queryRepository.SetDbContextInstance(_context);
            return await _queryRepository.GetAll().AsNoTracking().ToListAsync();
        }
    }
}
