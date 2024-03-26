﻿using OnlineRivalMarket.Application.Abstractions;
using OnlineRivalMarket.Application.Messaging;
using OnlineRivalMarket.Application.Services.AppServices;
using OnlineRivalMarket.Domain.AppEntities.Identity;
using OnlineRivalMarket.Domain.AppEntities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineRivalMarket.Domain.Dtos;

namespace OnlineRivalMarket.Application.Features.AppFeatures.AuthFeatures.Commands.GetTokenByRefreshToken
{
    public sealed class GetTokenByRefreshTokenCommandHandler : ICommandHandler<GetTokenByRefreshTokenCommand, GetTokenByRefreshTokenCommandResponse>
    {
        private readonly IJwtProvider _jwtProvider;
        private readonly UserManager<AppUser> _userManager;
        private readonly IAuthService _authService;
        public GetTokenByRefreshTokenCommandHandler(IJwtProvider jwtProvider, UserManager<AppUser> userManager, IAuthService authService)
        {
            _jwtProvider = jwtProvider;
            _userManager = userManager;
            _authService = authService;
        }
        public async Task<GetTokenByRefreshTokenCommandResponse> Handle(GetTokenByRefreshTokenCommand request, CancellationToken cancellationToken)
        {
            AppUser user = await _userManager.FindByIdAsync(request.UserId);
            if (user == null) throw new Exception("Kullanıcı bulunamadı!");
            if (user.RefreshToken != request.RefreshToken) throw new Exception("Refresh Token geçerli değil!");
            IList<UserAndCompanyRelationship> companies = await _authService.GetCompanyListByUserIdAsync(user.Id);
            IList<CompanyDto> companiesDto = companies.Select(s => new CompanyDto(s.Company.Id, s.Company.Name)).ToList();
            if (companies.Count() == 0) throw new Exception("Herhangi bir şikete kayıtlı değilsiniz!");
            GetTokenByRefreshTokenCommandResponse response = new(
                Token: await _jwtProvider.CreateTokenAsync(user),
                Email: user.Email,
                UserId: user.Id,
                NameLastName: user.NameLastName,
                Companies: companiesDto,
                Company: companiesDto.Where(p => p.CompanyId == request.CompanyId).FirstOrDefault(),
                Year: DateTime.Now.Year
                );
            return response;
        }
    }

}
