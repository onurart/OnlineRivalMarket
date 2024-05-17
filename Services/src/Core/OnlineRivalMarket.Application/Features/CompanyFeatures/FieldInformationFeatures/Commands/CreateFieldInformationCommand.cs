using Microsoft.AspNetCore.Http;
using OnlineRivalMarket.Application.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRivalMarket.Application.Features.CompanyFeatures.FieldInformationFeatures.Commands;

public sealed record CreateFieldInformationCommand
                                                  (
                                                   string CompanyId,
                                                   string CompetitorId,
                                                   string Description,
                                                   string Title,
                                                   IFormFile[]? Files
                                                   ) : ICommand<CreateFieldInformationCommandResponse>;
