using OnlineRivalMarket.Application.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRivalMarket.Application.Features.CompanyFeatures.FieldInformationFeatures.Commands;

    public sealed record CreateFieldInformationCommand
                                                      (
                                                       string Title,
                                                       string Description,
                                                       string Location,
                                                       string Source,
                                                       string CompanyId,
                                                       DateTime Date
                                                       ) : ICommand<CreateFieldInformationCommandResponse>;
