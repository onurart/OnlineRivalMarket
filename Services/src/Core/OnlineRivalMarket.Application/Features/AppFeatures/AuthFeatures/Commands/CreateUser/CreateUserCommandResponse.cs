using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRivalMarket.Application.Features.AppFeatures.AuthFeatures.Commands.CreateUser
{
    public sealed record CreateUserCommandResponse(string Message = "Kullanıcı kaydı başarıyla tamamlandı!");
}
