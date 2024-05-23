global using FluentValidation;
global using Mapster;
global using MediatR;
global using Microsoft.AspNetCore.Http;
global using Microsoft.AspNetCore.Identity;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.Logging;
global using Newtonsoft.Json;
global using OnlineRivalMarket.Application.Abstractions;
global using OnlineRivalMarket.Application.Features.AppFeatures.AuthFeatures.Commands.CreateUserAll;
global using OnlineRivalMarket.Application.Features.AppFeatures.MainRoleFeatures.Commands.CreateMainRole;
global using OnlineRivalMarket.Application.Features.AppFeatures.MainRoleFeatures.Commands.CreateRole;
global using OnlineRivalMarket.Application.Features.AppFeatures.MainRoleFeatures.Commands.RemoveMainRole;
global using OnlineRivalMarket.Application.Messaging;
global using OnlineRivalMarket.Application.Services;
global using OnlineRivalMarket.Application.Services.AppServices;
global using OnlineRivalMarket.Application.Services.CompanyServices;
global using OnlineRivalMarket.Domain.AppEntities;
global using OnlineRivalMarket.Domain.AppEntities.Identity;
global using OnlineRivalMarket.Domain.CompanyEntities;
global using OnlineRivalMarket.Domain.Dtos;
global using OnlineRivalMarket.Domain.Roles;
global using System.DirectoryServices.AccountManagement;
global using OnlineRivalMarket.Domain.Dtos.HomeTopDto;
global using EntityFrameworkCorePagination.Nuget.Pagination;
global using OnlineRivalMarket.Domain.Dtos.FieldInformationDtos;
global using OnlineRivalMarket.Domain.Dtos.ForeignCurrency;
global using OnlineRivalMarket.Domain.Dtos.IntelligenceDto;
global using OnlineRivalMarket.Domain.Dtos.Product;
global using OnlineRivalMarket.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
global using OnlineRivalMarket.Application.Features.AppFeatures.RoleFeatures.Commands.CreateRole;
global using OnlineRivalMarket.Application.Features.CompanyFeatures.BrandFeaures.Commands.CreateBrand;
global using OnlineRivalMarket.Application.Features.CompanyFeatures.CategoryFeatures.Commands.CreateCategory;
global using OnlineRivalMarket.Application.Features.CompanyFeatures.CompetitorsFeatures.Command.CreateCompetitors;
global using OnlineRivalMarket.Application.Features.CompanyFeatures.FieldInformationFeatures.Commands;
global using OnlineRivalMarket.Application.Features.CompanyFeatures.FieldInformationFeatures.Queries.FieldInformationDto;
global using OnlineRivalMarket.Application.Features.CompanyFeatures.FieldInformationFeatures.Queries.FieldInformationHome;
global using OnlineRivalMarket.Application.Features.CompanyFeatures.ForeignCurrency.Commamds;
global using OnlineRivalMarket.Application.Features.CompanyFeatures.IntelligenceRecordFeatures.Commands.CreateIntelligenceRecord;
global using OnlineRivalMarket.Application.Features.CompanyFeatures.LogFeatures.Queires.GetLogsByTableName;
global using OnlineRivalMarket.Application.Features.CompanyFeatures.VehicleGroupFeaures.Commands.CreateVehicleGroup;
global using OnlineRivalMarket.Application.Features.CompanyFeatures.VehicleTypeFeaures.Commands.CreateVehicleType;
global using System.Net;


















