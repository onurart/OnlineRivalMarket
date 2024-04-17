using OnlineRivalMarket.Application.Messaging;
using System.Windows.Input;

namespace OnlineRivalMarket.Application.Features.CompanyFeatures.VehicleTypeFeaures.Commands.CreateVehicleType;
public sealed record CreateVehicleTypeCommand(string Name,string companyId) : ICommand<CreateVehicleTypeCommandResponse>;
