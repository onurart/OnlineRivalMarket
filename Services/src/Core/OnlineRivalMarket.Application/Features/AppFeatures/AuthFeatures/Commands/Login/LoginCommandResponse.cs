using OnlineRivalMarket.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRivalMarket.Application.Features.AppFeatures.AuthFeatures.Commands.Login
{
    public sealed record LoginCommandResponse(
      TokenRefreshTokenDto Token,
      string Email,
      string UserId,
      string NameLastName,
      string MainRole,
      IList<CompanyDto?>? Companies = null, // İsteğe bağlı parametre
      CompanyDto? Company = null // İsteğe bağlı parametre
  );
}
