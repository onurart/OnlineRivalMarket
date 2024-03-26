﻿using Microsoft.AspNetCore.Identity;
using OnlineRivalMarket.Application.Abstractions;
using OnlineRivalMarket.Application.Messaging;
using OnlineRivalMarket.Application.Services.AppServices;
using OnlineRivalMarket.Domain.AppEntities;
using OnlineRivalMarket.Domain.AppEntities.Identity;
using OnlineRivalMarket.Domain.Dtos;
namespace OnlineRivalMarket.Application.Features.AppFeatures.AuthFeatures.Commands.Login
{
    public class LoginCommandHandler : ICommandHandler<LoginCommand, LoginCommandResponse>
    {
        private readonly IJwtProvider _jwtProvider;
        private readonly UserManager<AppUser> _userManager;
        private readonly IAuthService _authService;
        public LoginCommandHandler(IJwtProvider jwtProvider, UserManager<AppUser> userManager, IAuthService authService)
        {
            _jwtProvider = jwtProvider;
            _userManager = userManager;
            _authService = authService;
        }
        public async Task<LoginCommandResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            AppUser user = await _authService.GetByEmailOrUserNameAsync(request.EmailOrUserName);
            if (user == null) throw new Exception("Kullanıcı bulunamadı!");

            var checkUser = await _authService.CheckPasswordAsync(user, request.Password);
            if (!checkUser) throw new Exception("Şifreniz yanlış!");

            IList<UserAndCompanyRelationship> companies = await _authService.GetCompanyListByUserIdAsync(user.Id);
            IList<CompanyDto> companiesDto = companies.Select(s => new CompanyDto(
                s.Company.Id, s.Company.Name)).ToList();
            var mainrole = await _authService.GetMainRolesByUserId(user.Id);
            //if (companies.Count() == 0) throw new Exception("Herhangi bir şikete kayıtlı değilsiniz!");

            LoginCommandResponse response = new(
                Token: await _jwtProvider.CreateTokenAsync(user),
                Email: user.Email,
                UserId: user.Id,
                NameLastName: user.NameLastName,
                MainRole: mainrole,
                Companies: companiesDto,
                Company: null
                );

            return response;
        }
    }
}
