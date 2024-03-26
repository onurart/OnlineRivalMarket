using OnlineRivalMarket.Application.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRivalMarket.Application.Features.AppFeatures.AuthFeatures.Commands.CreateUser
{
    public sealed record CreateUserCommand(string FirstName, string LastName, string UserName, string Email, string NameLastName, string Password) : ICommand<CreateUserCommandResponse>;
}
