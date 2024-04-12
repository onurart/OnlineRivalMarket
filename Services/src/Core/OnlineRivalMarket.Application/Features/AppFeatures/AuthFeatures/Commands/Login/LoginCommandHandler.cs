using Microsoft.AspNetCore.Identity;
using OnlineRivalMarket.Application.Abstractions;
using OnlineRivalMarket.Application.Messaging;
using OnlineRivalMarket.Application.Services.AppServices;
using OnlineRivalMarket.Domain.AppEntities;
using OnlineRivalMarket.Domain.AppEntities.Identity;
using OnlineRivalMarket.Domain.Dtos;
using System.DirectoryServices.AccountManagement;
namespace OnlineRivalMarket.Application.Features.AppFeatures.AuthFeatures.Commands.Login
{
    public class LoginCommandHandler : ICommandHandler<LoginCommand, LoginCommandResponse>
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
        public async Task<LoginCommandResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
            {
            AppUser user = await _authService.GetByEmailOrUserNameAsync(request.EmailOrUserName);

            if (user == null)
            {
                bool loginBasarili = false;
                using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, "192.168.181.201"))
                {
                    loginBasarili = pc.ValidateCredentials(request.EmailOrUserName, request.Password);//kullanıcı adı ve şifre
                    if (loginBasarili)
                    {
                        UserPrincipal yourUser = UserPrincipal.FindByIdentity(pc, request.EmailOrUserName);
                        if (yourUser != null)
                        {
                            await _userManager.CreateAsync(new AppUser
                            {
                                FirstName = yourUser.GivenName,
                                LastName = yourUser.Surname,
                                RefreshToken = yourUser.Sid.Value.ToString(), //Guid.NewGuid().ToString(),
                                UserName = yourUser.SamAccountName,
                                Email = yourUser.EmailAddress,
                                Id = yourUser.Guid.ToString(), //Guid.NewGuid().ToString(),
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

                //throw new Exception("Kullanıcı bulunamadı!");
            }
            else
            {
                bool loginBasarili = false;
                using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, "192.168.181.201"))
                {
                    loginBasarili = pc.ValidateCredentials(request.EmailOrUserName, request.Password);//kullanıcı adı ve şifre
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
            //    AppUser
            user = await _authService.GetByEmailOrUserNameAsync(request.EmailOrUserName);
            if (user == null) throw new Exception("Kullanıcı bulunamadı!");

            var checkUser = await _authService.CheckPasswordAsync(user, request.Password);
            if (!checkUser) throw new Exception("Şifreniz yanlış!");
            var mainrole = await _authService.GetMainRolesByUserId(user.Id);
            //if (companies.Count() == 0) throw new Exception("Herhangi bir şikete kayıtlı değilsiniz!");

            LoginCommandResponse response = new(
                        Token: await _jwtProvider.CreateTokenAsync(user),
                        Email: user.Email,
                        UserId: user.Id,
                        NameLastName: user.NameLastName,
                        MainRole: mainrole
                


                        );
            return response;
        }
    }
}
