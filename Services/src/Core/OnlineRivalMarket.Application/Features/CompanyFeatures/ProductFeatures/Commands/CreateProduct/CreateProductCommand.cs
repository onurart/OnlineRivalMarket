﻿namespace OnlineRivalMarket.Application.Features.CompanyFeatures.ProductFeatures.Commands.CreateProduct;
public  record CreateProductCommand
                                                (
                                                 string? ProductCode,
                                                 string? ProducerCode,
                                                 string? ProductName,
                                                 string? VehicleTypeId,
                                                 string? VehicleGroupId,
                                                 string? CategoryId,
                                                 string? BrandId,
                                                 string? CompanyId
                                                 ) : ICommand<CreateProductCommandResponse>;
