using OnlineRivalMarket.Application.Messaging;
using System.Windows.Input;

namespace OnlineRivalMarket.Application.Features.CompanyFeatures.VehicleGroupFeaures.Commands.CreateVehicleGroup;

public sealed record CreateVehicleGroupCommand
                                              (string Name,string CompanyId) : ICommand<CreateVehicleGroupCommandResponse>;
