using OnlineRivalMarket.Domain.AppEntities.Identity;
using OnlineRivalMarket.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRivalMarket.Application.Abstractions
{
    public interface IJwtProvider
    {
        Task<TokenRefreshTokenDto> CreateTokenAsync(AppUser user);
    }
}
