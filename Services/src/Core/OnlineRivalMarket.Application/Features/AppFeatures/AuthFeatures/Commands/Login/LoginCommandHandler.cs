using Microsoft.AspNetCore.Identity;
using OnlineRivalMarket.Application.Abstractions;
using OnlineRivalMarket.Application.Messaging;
using OnlineRivalMarket.Application.Services;
using OnlineRivalMarket.Application.Services.AppServices;
using OnlineRivalMarket.Domain.AppEntities;
using OnlineRivalMarket.Domain.AppEntities.Identity;
using OnlineRivalMarket.Domain.Dtos;
using System.DirectoryServices.AccountManagement;
namespace OnlineRivalMarket.Application.Features.AppFeatures.AuthFeatures.Commands.Login
{
    public class LoginCommandHandler : ICommandHandler<LoginCommand, Result<LoginCommandResponse>>
    {
        private readonly IJwtProvider _jwtProvider;
        private readonly UserManager<AppUser> _userManager;
        private readonly IAuthService _authService;
        private readonly IMainRoleAndUserRelationshipService _mainRoleAndUserService;
        private readonly IUserRoleService _userRoleService;
        public LoginCommandHandler(IJwtProvider jwtProvider, UserManager<AppUser> userManager, IAuthService authService, IMainRoleAndUserRelationshipService mainRoleAndUserService, IUserRoleService userRoleService)
        {
            _jwtProvider = jwtProvider;
            _userManager = userManager;
            _authService = authService;
            _mainRoleAndUserService = mainRoleAndUserService;
            _userRoleService = userRoleService;
        }
        public async Task<Result<LoginCommandResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            AppUser user = await _authService.GetByEmailOrUserNameAsync(request.EmailOrUserName);

            if (user == null)
            {
                bool loginBasarili = false;
                using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, "192.168.181.201"))
                {
                    loginBasarili = pc.ValidateCredentials(request.EmailOrUserName, request.Password);
                    if (loginBasarili)
                    {
                        UserPrincipal yourUser = UserPrincipal.FindByIdentity(pc, request.EmailOrUserName);
                        if (yourUser != null)
                        {
                            await _userManager.CreateAsync(new AppUser
                            {
                                FirstName = yourUser.GivenName,
                                LastName = yourUser.Surname,
                                RefreshToken = yourUser.Sid.Value.ToString(),
                                UserName = yourUser.SamAccountName,
                                Email = yourUser.EmailAddress,
                                Id = yourUser.Guid.ToString(),
                                NameLastName = yourUser.GivenName + " " + yourUser.Surname
                            }, "1q2w3E*");

                            user = await _authService.GetByEmailOrUserNameAsync(request.EmailOrUserName);
                            MainRoleAndUserRelationship mainRoleAndUserRelationship = new(Guid.NewGuid().ToString(), user.Id, "f42c9b68-7ea3-4812-8697-1c8667e29e31");
                            await _mainRoleAndUserService.CreateAsync(mainRoleAndUserRelationship, cancellationToken);

                            AppUserRole appUserRole = new(Guid.NewGuid().ToString(), "00000003-7ea3-4812-8697-1c8667e29e31", user.Id);
                            await _userRoleService.AddAsync(appUserRole, cancellationToken);
                        }
                    }

                }
            }
            else
            {
                bool loginBasarili = false;
                using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, "192.168.181.201"))
                {
                    loginBasarili = pc.ValidateCredentials(request.EmailOrUserName, request.Password);
                    if (loginBasarili)
                    {
                        user = await _authService.GetByEmailOrUserNameAsync(request.EmailOrUserName);
                        var mainrole2 = await _authService.GetMainRolesByUserId(user.Id);
                        LoginCommandResponse response3 = new(
                                               Token: await _jwtProvider.CreateTokenAsync(user),
                                               Email: user.Email,
                                               UserId: user.Id,
                                               NameLastName: user.NameLastName,
                                               MainRole: mainrole2



                                               );
                        return response3;
                    }
                    else
                    {
                        user = null;
                    }

                }
            }
            user = await _authService.GetByEmailOrUserNameAsync(request.EmailOrUserName);
            if (user is null) 
            {
                return Result<LoginCommandResponse>.Failure(200, "user not found");   
            }
            var checkUser = await _authService.CheckPasswordAsync(user, request.Password);
            if (!checkUser)
            {
                return Result<LoginCommandResponse>.Failure(200, "Password is wrong");
            }
            var mainrole = await _authService.GetMainRolesByUserId(user.Id);
            IList<UserAndCompanyRelationship> companies = await _authService.GetCompanyListByUserIdAsync(user.Id);
            IList<CompanyDto> companiesDto = companies.Select(s => new CompanyDto(s.Company.Id, s.Company.Name)).ToList();          
            IList<CompanyDto> companiesDtow = companies.Select(s => new CompanyDto(s.Company.Id, s.Company.Name)).ToList();
            LoginCommandResponse response = new(
                        Token: await _jwtProvider.CreateTokenAsync(user),
                        Email: user.Email,
                        UserId: user.Id,
                        NameLastName: user.NameLastName,
                        MainRole: mainrole,
                        Companies: companiesDto
                        );
            return Result<LoginCommandResponse>.Succeed(response);
        }
    }
}
