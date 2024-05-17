using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineRivalMarket.Application.Features.AppFeatures.AuthFeatures.Commands.ChangePassword;
using OnlineRivalMarket.Application.Features.AppFeatures.AuthFeatures.Commands.CreateUser;
using OnlineRivalMarket.Application.Features.AppFeatures.AuthFeatures.Commands.CreateUserAll;
using OnlineRivalMarket.Application.Features.AppFeatures.AuthFeatures.Commands.GetTokenByRefreshToken;
using OnlineRivalMarket.Application.Features.AppFeatures.AuthFeatures.Commands.Login;
using OnlineRivalMarket.Application.Features.AppFeatures.AuthFeatures.Queries.GetAllUser;
using OnlineRivalMarket.Application.Features.AppFeatures.AuthFeatures.Queries.GetMainRolesByUserId;
using OnlineRivalMarket.Application.Services;
using OnlineRivalMarket.Presentation.Abstraction;
namespace OnlineRivalMarket.Presentation.Controller;

public class AuthController : ApiController
{
    private readonly ILogger<AuthController> _logger;
    public AuthController(IMediator mediator, ILogger<AuthController> logger) : base(mediator)
    {
        _logger = logger;
    }
    //public class TokenVerificationRequest
    //{
    //    public string Token { get; set; }
    //}
    //[HttpPost("[action]")]
    //[AllowAnonymous]
    //public async Task<IActionResult> VerifyToken([FromBody] TokenVerificationRequest request)
    //{
    //    if (!ModelState.IsValid)
    //    {
    //        return BadRequest(ModelState);
    //    }
    //    var tokenHandler = new JwtSecurityTokenHandler();
    //    var key = Encoding.ASCII.GetBytes("This is my secret key. Yes, yes secret key.");
    //    var validationParameters = new TokenValidationParameters
    //    {
    //        ValidateIssuerSigningKey = true,
    //        IssuerSigningKey = new SymmetricSecurityKey(key),
    //        ValidateIssuer = true,
    //        ValidIssuer = "www.mysitem.com",
    //        ValidateAudience = false,
    //        ValidAudience = "www.mysitem.com",
    //        ValidateLifetime = true,
    //        ClockSkew = TimeSpan.Zero
    //    };
    //    SecurityToken validatedToken;
    //    try
    //    {
    //        tokenHandler.ValidateToken(request.Token, validationParameters, out validatedToken);

    //        if (validatedToken is JwtSecurityToken jwtSecurityToken)
    //        {
    //            // Token içindeki parametreleri al
    //            var tokenParams = new
    //            {
    //                Username = jwtSecurityToken.Claims.FirstOrDefault(claim => claim.Type == "email")?.Value,
    //                UserId = jwtSecurityToken.Claims.First(claim => claim.Type == "UserId")?.Type,
    //                actor = jwtSecurityToken.Claims.FirstOrDefault(claim => claim.Type == "actor ")?.Value,
    //                // Diğer parametreleri buraya ekle
    //            };

    //            return Ok(new { message = "Token is valid", tokenParams });
    //        }
    //        else
    //        {
    //            // Geçerli token bir JwtSecurityToken değilse işleme devam edemez
    //            return Unauthorized(new { message = "Invalid token", error = "Token is not a valid JWT" });
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        return Unauthorized(new { message = "Invalid token", error = ex.Message });
    //    }
    //}


    [AllowAnonymous]
    [HttpPost("[action]")]
    public async Task<IActionResult> Login(LoginCommand request)
    {
        var loginCommandValidator = new LoginCommandValidator();
        var validationResult = loginCommandValidator.Validate(request);

        if (!validationResult.IsValid)
        {
            var errorMessages = validationResult.Errors.Select(error => error.ErrorMessage).ToList();
            var error=Result<string>.Failure(errorMessages);

            return StatusCode(200, error);
            //return BadRequest(Result<object>.Failure(200, errorMessages));
        }

        var response = await _mediator.Send(request);
        //_logger.LogInformation(response.NameLastName + " User Login!");
        return StatusCode(response.StatusCode, response);
    }
    //[AllowAnonymous]
    //[HttpPost("[action]")]
    //public async Task<IActionResult> Login(LoginCommand request)
    //{
    //    var  response = await _mediator.Send(request);
    //    return StatusCode(response.StatusCode,response);
    //}
    [HttpPost("[action]")]
    public async Task<IActionResult> GetTokenByRefreshToken(GetTokenByRefreshTokenCommand request)
    {
        GetTokenByRefreshTokenCommandResponse response = await _mediator.Send(request);
        return Ok(response);
    }
    [HttpPost("[action]")]
    public async Task<IActionResult> ChangePassword(ChangePasswordCommand request)
    {
        ChangePasswordCommandResponse response = await _mediator.Send(request);
        return Ok(response);
    }
    [HttpPost("[action]")]
    public async Task<IActionResult> GetMainRolesByUserId(GetMainRolesByUserIdQuery request)
    {
        GetMainRolesByUserIdQueryResponse response = await _mediator.Send(request);
        return Ok(response);
    }
    [HttpPost("[action]")]
    public async Task<IActionResult> CreateUser(CreateUserCommand request)
    {
        CreateUserCommandResponse response = await _mediator.Send(request);
        return Ok(response);
    }
    [HttpPost("[action]")]
    public async Task<IActionResult> CreateAllUser(CreateUserAllCommand request)
    {
        CreateUserAllCommandResponse response = await _mediator.Send(request);
        return Ok(response);
    }
    [HttpGet("[action]")]
    public async Task<IActionResult> GetAllUser()
    {
        _logger.LogInformation("Get all User");
        GetAllUserQuery request = new();
        GetAllUserQueryResponse response = await _mediator.Send(request);
        return Ok(response);
    }
}