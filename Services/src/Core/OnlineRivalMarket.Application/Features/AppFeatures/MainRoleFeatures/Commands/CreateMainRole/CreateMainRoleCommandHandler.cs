namespace OnlineRivalMarket.Application.Features.AppFeatures.MainRoleFeatures.Commands.CreateMainRole;
public sealed class CreateMainRoleCommandHandler : ICommandHandler<CreateMainRoleCommand, CreateMainRoleCommandResponse>
{
    private readonly IMainRoleService _mainRoleService;
    public CreateMainRoleCommandHandler(IMainRoleService mainRoleService)
    {
        _mainRoleService = mainRoleService;
    }
    public async Task<CreateMainRoleCommandResponse> Handle(CreateMainRoleCommand request, CancellationToken cancellationToken)
    {
        MainRole checkMainRoleTitle = await _mainRoleService.GetByTitleAndCompanyId(request.Title, cancellationToken);
        if (checkMainRoleTitle != null) throw new Exception("Bu rol daha önce kaydedilmiş!");
        MainRole mainRole = new(
    Guid.NewGuid().ToString(),
    request.Title);
        await _mainRoleService.CreateAsync(mainRole, cancellationToken);
        return new();
    }
}