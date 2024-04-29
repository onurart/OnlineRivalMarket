using EntityFrameworkCorePagination.Nuget.Pagination;
using OnlineRivalMarket.Domain.Dtos.HomeTopDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRivalMarket.Application.Features.CompanyFeatures.CampaignFeaures.Queries.GetAllDtoAsync;
public sealed record GetAllCampaingDtoResponse(PaginationResult<HomeTopCampaignDto> Data);

