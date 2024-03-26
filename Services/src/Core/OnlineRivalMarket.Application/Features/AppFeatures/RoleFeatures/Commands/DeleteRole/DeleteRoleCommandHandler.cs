using OnlineRivalMarket.Application.Messaging;
using OnlineRivalMarket.Application.Services.AppServices;
using OnlineRivalMarket.Domain.AppEntities.Identity;
namespace OnlineRivalMarket.Application.Features.AppFeatures.RoleFeatures.Commands.DeleteRole;
public sealed class DeleteRoleCommandHandler : ICommandHandler<DeleteRoleCommand, DeleteRoleCommandResponse>
{
    private readonly IRoleService _roleService;
    public DeleteRoleCommandHandler(IRoleService roleService)
    {
        _roleService = roleService;
    }
    public async Task<DeleteRoleCommandResponse> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
    {
        AppRole role = await _roleService.GetById(request.Id);
        if (role == null) throw new Exception("Role bulunamadı!");

        await _roleService.DeleteAsync(role);

        return new();
    }
}