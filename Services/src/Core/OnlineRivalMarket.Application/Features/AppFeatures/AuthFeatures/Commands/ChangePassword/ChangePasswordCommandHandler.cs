using OnlineRivalMarket.Application.Messaging;
using OnlineRivalMarket.Application.Services.AppServices;
using OnlineRivalMarket.Domain.AppEntities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRivalMarket.Application.Features.AppFeatures.AuthFeatures.Commands.ChangePassword
{
    public class ChangePasswordCommandHandler : ICommandHandler<ChangePasswordCommand, ChangePasswordCommandResponse>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IAuthService _authService;

        public ChangePasswordCommandHandler(UserManager<AppUser> userManager, IAuthService authService)
        {
            _userManager = userManager;
            _authService = authService;
        }

        public async Task<ChangePasswordCommandResponse> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            AppUser user = await _authService.GetByEmailOrUserNameAsync(request.email);
            var users = await _userManager.ChangePasswordAsync(user, request.currentPassword, request.newPassword);
            if (users.Succeeded)
            {
                return new ChangePasswordCommandResponse("Kullanıcı Şifresi Değiştirme Başarılı");
            }

            else
            {
                var errors = new string[] { "Current UserStore doesn't implement IUserPasswordStore" };
                //return IdentityResult.Failed(errors);
                var err = "";
                foreach (var error in users.Errors)
                {
                    err = error.Description;
                }
                return new ChangePasswordCommandResponse(err);
            }
        }

    }
}
