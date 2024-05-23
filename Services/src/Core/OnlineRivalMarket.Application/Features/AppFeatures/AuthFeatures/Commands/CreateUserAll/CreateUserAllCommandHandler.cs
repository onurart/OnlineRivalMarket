namespace ATTicOnlineRivalMarketket.Application.Features.AppFeatures.AuthFeatures.Commands.CreateUserAll;
public sealed class CreateUserAllCommandHandler : ICommandHandler<CreateUserAllCommand, CreateUserAllCommandResponse>
{
    private readonly IAuthService _authService;
    private readonly UserManager<AppUser> _userManager;
    private readonly IMainRoleAndUserRelationshipService _mainRoleAndUserService;
    private readonly IUserRoleService _userRoleService;
    public CreateUserAllCommandHandler(IAuthService authService, UserManager<AppUser> userManager, IMainRoleAndUserRelationshipService mainRoleAndUserService, IUserRoleService userRoleService)
    {
        _authService = authService;
        _userManager = userManager;
        _mainRoleAndUserService = mainRoleAndUserService;
        _userRoleService = userRoleService;
    }

    public async Task<CreateUserAllCommandResponse> Handle(CreateUserAllCommand request, CancellationToken cancellationToken)
    {
        using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, "motorasin.com"))
        {
            UserPrincipal userPrincipal = new UserPrincipal(pc);
            userPrincipal.Enabled = true;
            PrincipalSearcher principalSearcher = new PrincipalSearcher(userPrincipal);
            List<UserPrincipal> principalSearchResult = principalSearcher.FindAll().Cast<UserPrincipal>().OrderBy(u => u.SamAccountName).ToList();
            //işlemler
            foreach (var principal in principalSearchResult)
            {
                if (principal.Surname != null && principal.EmailAddress != null&&principal.GivenName!=null)
                {
                    AppUser user2 = await _authService.GetByEmailOrUserNameAsync(principal.EmailAddress);
                    if (user2 == null)
                    {
                       
                            _userManager.CreateAsync(new AppUser
                            {
                                FirstName = principal.GivenName,
                                LastName = principal.Surname,
                                RefreshToken = principal.Sid.Value.ToString(), //Guid.NewGuid().ToString(),
                                UserName = principal.SamAccountName,
                                Email = principal.EmailAddress,
                                Id = principal.Guid.ToString(), //Guid.NewGuid().ToString(),
                                NameLastName = principal.GivenName + " " + principal.Surname
                            }, "1q2w3E*").Wait();
                        user2 = await _authService.GetByEmailOrUserNameAsync(principal.EmailAddress);
                        MainRoleAndUserRelationship mainRoleAndUserRelationship = new(Guid.NewGuid().ToString(), user2.Id, "f42c9b68-7ea3-4812-8697-1c8667e29e31");
                        await _mainRoleAndUserService.CreateAsync(mainRoleAndUserRelationship, cancellationToken);

                        AppUserRole appUserRole = new(Guid.NewGuid().ToString(), "00000003-7ea3-4812-8697-1c8667e29e31", user2.Id);
                        await _userRoleService.AddAsync(appUserRole, cancellationToken);

                    }
                }

            }
        }
        return new();
    }
}
