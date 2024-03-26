using OnlineRivalMarket.Application.Messaging;
using OnlineRivalMarket.Application.Services.AppServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRivalMarket.Application.Features.AppFeatures.AuthFeatures.Queries.GetMainRolesByUserId
{
    public sealed class GetMainRolesByUserIdQueryHandler : IQueryHandler<GetMainRolesByUserIdQuery, GetMainRolesByUserIdQueryResponse>
    {
        private readonly IAuthService _authService;

        public GetMainRolesByUserIdQueryHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<GetMainRolesByUserIdQueryResponse> Handle(GetMainRolesByUserIdQuery request, CancellationToken cancellationToken)
        {
            string roles = await _authService.GetMainRolesByUserId(request.UserId);
            return new(roles);
        }
    }
}
