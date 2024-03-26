using OnlineRivalMarket.Application.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRivalMarket.Application.Features.AppFeatures.AuthFeatures.Commands.ChangePassword
{
    public sealed record ChangePasswordCommand(string email, string currentPassword, string newPassword) : ICommand<ChangePasswordCommandResponse>;
}
