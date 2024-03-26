using OnlineRivalMarket.Application.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRivalMarket.Application.Features.CompanyFeatures.CampaignFeaures.Commands.CreateCampaign;
public sealed record CreateCampaignCommand
                                         (
                                           string ? CompetitorsId,
                                           string ? BrandId,
                                           string ? CategoryId,
                                           DateTime? StartTime,
                                           DateTime? EndTime,
                                           string? Description,
                                           string? ImageUrl,
                                            string? CompanyId
                                         ) :  ICommand<CreateCampaignCommandResponse>;
            
        