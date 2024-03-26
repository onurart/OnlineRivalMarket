using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRivalMarket.Application.Features.AppFeatures.AuthFeatures.Commands.ChangePassword
{
    public sealed record ChangePasswordCommandResponse(string Message = "Kullanıcı Şifresi Başarıyla Değiştirildi!");
}
