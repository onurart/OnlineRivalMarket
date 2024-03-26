using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineRivalMarket.Application.Features.CompanyFeatures.ProductFeatures.Commands.CreateProduct;
using OnlineRivalMarket.Application.Services.CompanyServices;
using OnlineRivalMarket.Domain;
using OnlineRivalMarket.Domain.CompanyEntities;
using OnlineRivalMarket.Domain.Repositories.CompanyDbContext.ProductRepositories;
using OnlineRivalMarket.Domain.UnitOfWorks;
using OnlineRivalMarket.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRivalMarket.Persistance.Services.CompanyServices
{
    public sealed class ProductService : IProductService
    {
        private readonly IProductCommandRepository _commandRepository;
        private readonly IProductQueryRepository _queryRepository;
        private readonly IContextService _contextService;
        private readonly ICompanyDbUnitOfWork _companyDbUnitOfWork;
        private readonly IMapper _mapper;
        private CompanyDbContext _context;
        public ProductService(IProductCommandRepository commandRepository, IProductQueryRepository queryRepository, IContextService contextService, ICompanyDbUnitOfWork companyDbUnitOfWork, IMapper mapper)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
            _contextService = contextService;
            _companyDbUnitOfWork = companyDbUnitOfWork;
            _mapper = mapper;
        }

        public async Task<Product> CreateProductAsync(CreateProductCommand requst, CancellationToken cancellationToken)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(requst.CompanyId);
            _commandRepository.SetDbContextInstance(_context);
            _companyDbUnitOfWork.SetDbContextInstance(_context);
            Product product = _mapper.Map<Product>(requst);
            product.Id = Guid.NewGuid().ToString();
            await _commandRepository.AddAsync(product, cancellationToken);
            await _companyDbUnitOfWork.SaveChangesAsync(cancellationToken);
            return product;
        }

        public async Task<IList<Product>> GetAllAsync(string companyId)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
            _queryRepository.SetDbContextInstance(_context);
            return await _queryRepository.GetAll().AsNoTracking().ToListAsync();
        }

        public async Task UpdateAsync(Product product, string companyId)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
            _queryRepository.SetDbContextInstance(_context);
            _companyDbUnitOfWork.SetDbContextInstance(_context);
            _commandRepository.Update(product);
            await _companyDbUnitOfWork.SaveChangesAsync();
        }
    }
}
