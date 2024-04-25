﻿using AutoMapper;
using Azure.Core;
using EntityFrameworkCorePagination.Nuget.Pagination;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineRivalMarket.Application.Features.CompanyFeatures.CategoryFeatures.Commands.CreateCategory;
using OnlineRivalMarket.Application.Features.CompanyFeatures.CategoryFeatures.Commands.Queries.GetAllCategory;
using OnlineRivalMarket.Application.Services.CompanyServices;
using OnlineRivalMarket.Domain;
using OnlineRivalMarket.Domain.AppEntities.Identity;
using OnlineRivalMarket.Domain.CompanyEntities;
using OnlineRivalMarket.Domain.Dtos;
using OnlineRivalMarket.Domain.Repositories.CompanyDbContext.CategoryRepository;
using OnlineRivalMarket.Domain.UnitOfWorks;
using OnlineRivalMarket.Persistance.Configurations;
using OnlineRivalMarket.Persistance.Context;
namespace OnlineRivalMarket.Persistance.Services.CompanyServices;
public sealed class CategoryService : ICategoryService
{
    private readonly ICategoryCommandRepository _categoryCommandRepository;
    private readonly ICategoryQueryRepository _categoryQueryRepository;
    private readonly ICompanyDbUnitOfWork _unitOfWork;
    private readonly IContextService _contextService;
    private readonly IMapper _mapper;
    private CompanyDbContext _context;
    public CategoryService(ICategoryCommandRepository categoryCommandRepository, ICategoryQueryRepository categoryQueryRepository, ICompanyDbUnitOfWork unitOfWork, IContextService contextService, IMapper mapper)
    {
        _categoryCommandRepository = categoryCommandRepository;
        _categoryQueryRepository = categoryQueryRepository;
        _unitOfWork = unitOfWork;
        _contextService = contextService;
        _mapper = mapper;
    }
    public async Task<Category> CreateCategoryAsync(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _categoryCommandRepository.SetDbContextInstance(_context);
        _unitOfWork.SetDbContextInstance(_context);
        Category category = _mapper.Map<Category>(request);
        category.Id = Guid.NewGuid().ToString();
        await _categoryCommandRepository.AddAsync(category, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return category;
    }

    public async Task<PaginationResult<Category>> GetAllCategoryAsync(GetAllCategoryQuery request)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _categoryQueryRepository.SetDbContextInstance(_context);
        PaginationResult<Category> result = await _categoryQueryRepository.GetAll(false).OrderByDescending(p => p.CreatedDate).ToPagedListAsync(request.PageNumber, request.PageSize);


        int count = _categoryQueryRepository.GetAll().Count();
        IList<Category> logDtos = new List<Category>();
        if (result.Datas != null)
        {
            foreach (var item in result.Datas)
            {
                Category logDto = new()
                {
                    Id = item.Id,
                    CreatedDate = item.CreatedDate,
                    Name = item.Name,
                };
                logDtos.Add(logDto);
            }
        }
        PaginationResult<Category> requestResult = new(
           pageNumber: result.PageNumber,
           pageSize: result.PageSize,
           totalCount: count,
           datas: logDtos);

        return requestResult;
    }
}
