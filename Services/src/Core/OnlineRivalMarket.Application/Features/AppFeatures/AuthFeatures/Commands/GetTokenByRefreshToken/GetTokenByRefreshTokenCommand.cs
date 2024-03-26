using OnlineRivalMarket.Application.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRivalMarket.Application.Features.AppFeatures.AuthFeatures.Commands.GetTokenByRefreshToken
{
    public sealed record GetTokenByRefreshTokenCommand(string UserId, string RefreshToken, string CompanyId) : ICommand<GetTokenByRefreshTokenCommandResponse>;
}
