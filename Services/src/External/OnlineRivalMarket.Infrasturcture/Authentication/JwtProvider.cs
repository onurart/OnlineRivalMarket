namespace OnlineRivalMarket.Infrasturcture.Authentication
{
    public sealed class JwtProvider : IJwtProvider
    {
        private readonly JwtOptions _jwtOptions;
        private readonly UserManager<AppUser> _userManager;
        private readonly IAuthService _authService;
        private readonly IUserRoleService _roleService;
        private readonly ICompanyService _companyService;
        private readonly IUserAndCompanyRelationshipService _userAndCompanyRelationshipService;
        public JwtProvider(IOptions<JwtOptions> jwtOptions, UserManager<AppUser> userManager, IAuthService authService, IUserRoleService roleService, ICompanyService companyService = null, IUserAndCompanyRelationshipService userAndCompanyRelationshipService = null)
        {
            _jwtOptions = jwtOptions.Value;
            _userManager = userManager;
            _authService = authService;
            _roleService = roleService;
            _companyService = companyService;
            _userAndCompanyRelationshipService = userAndCompanyRelationshipService;
        }
        public async Task<TokenRefreshTokenDto> CreateTokenAsync(AppUser user)
        {
            var mainrole = await _authService.GetMainRolesByUserId(user.Id);
            var roles = await _roleService.GetListByUserId(user.Id, default);
            var userandcompany = await _userAndCompanyRelationshipService.GetListByUserId(user.Id);
            var sass = userandcompany.Select(x => x.CompanyId);

            if (userandcompany != null)
            {

            }
            var claims = new Claim[]
            {
            new Claim(JwtRegisteredClaimNames.Sub,user.NameLastName),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
             new Claim(JwtRegisteredClaimNames.UniqueName, mainrole),


            new Claim(ClaimTypes.Authentication, user.Id),
            new Claim(ClaimTypes.Role, String.Join(",", roles.ToList())),
            new Claim(ClaimTypes.Actor, String.Join(",", sass.ToList()))
            };
            DateTime expires = DateTime.Now.AddDays(1);
            JwtSecurityToken jwtSecurityToken = new(
    issuer: _jwtOptions.Issuer,
    audience: _jwtOptions.Audience,
    claims: claims,
    notBefore: DateTime.Now,
    expires: expires,
    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey)), SecurityAlgorithms.HmacSha256));
            string token = new JwtSecurityTokenHandler()
     .WriteToken(jwtSecurityToken);
            string refreshToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpires = expires.AddDays(1);
            await _userManager.UpdateAsync(user);
            return new(token, refreshToken, user.RefreshTokenExpires);
        }
    }
}
