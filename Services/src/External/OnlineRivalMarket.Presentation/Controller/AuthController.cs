﻿using MediatR;
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
    [AllowAnonymous]
    [HttpPost("[action]")]
    public async Task<IActionResult> Login(LoginCommand request)
    {
        var loginCommandValidator = new LoginCommandValidator();
        var validationResult = loginCommandValidator.Validate(request);

        if (!validationResult.IsValid)
        {
            var errorMessages = validationResult.Errors.Select(error => error.ErrorMessage).ToList();
            return BadRequest(Result<object>.Failure(400, errorMessages));
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