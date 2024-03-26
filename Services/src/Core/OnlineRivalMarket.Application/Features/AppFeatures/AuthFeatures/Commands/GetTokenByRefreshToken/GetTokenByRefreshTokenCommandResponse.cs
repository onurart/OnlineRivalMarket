using OnlineRivalMarket.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRivalMarket.Application.Features.AppFeatures.AuthFeatures.Commands.GetTokenByRefreshToken
{
    public sealed record GetTokenByRefreshTokenCommandResponse(TokenRefreshTokenDto Token, string Email, string UserId, string NameLastName, IList<CompanyDto> Companies, int Year, CompanyDto Company);
}
