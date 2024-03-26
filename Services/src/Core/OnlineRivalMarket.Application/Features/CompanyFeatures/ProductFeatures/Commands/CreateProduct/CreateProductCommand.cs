using OnlineRivalMarket.Application.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OnlineRivalMarket.Application.Features.CompanyFeatures.ProductFeatures.Commands.CreateProduct
{
    public sealed record class CreateProductCommand
                                                    (string Name,
                                                     string? CompanyId) : ICommand<CreateProductCommandResponse>;
    
}
