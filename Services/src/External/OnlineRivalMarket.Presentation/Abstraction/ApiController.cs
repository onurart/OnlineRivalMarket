﻿namespace OnlineRivalMarket.Presentation.Abstraction;
[ApiController]
[Route("api/[controller]")]
[Authorize(AuthenticationSchemes = "Bearer")]
public abstract class ApiController : ControllerBase
{
    protected readonly IMediator _mediator;
    protected ApiController(IMediator mediator)
    {
        _mediator = mediator;
    }
}