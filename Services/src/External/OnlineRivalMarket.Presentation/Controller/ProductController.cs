using OnlineRivalMarket.Application.Features.CompanyFeatures.ProductFeatures.Queries.GetAllProduct;

namespace OnlineRivalMarket.Presentation.Controller;
[Authorize(AuthenticationSchemes = "Bearer")]
public class ProductController : ApiController
{
    public ProductController(IMediator mediator) : base(mediator)
    {
    }
    [HttpPost("[action]")]
    public async Task<IActionResult> CreateProduct(CreateProductCommand request, CancellationToken cancellationToken)
    {
        CreateProductCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
    [HttpGet("[action]/{companyid}")]
    public async Task<IActionResult> GetAllProduct(string companyid)
    {
        GetAllProductCommandQuery request = new(companyid);
        GetAllProductCommandResponse response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> GetAllaginationAsync(GetAllProductQuery companid)
    {
        GetAllProductQueryResponse response = await _mediator.Send(companid);
        return Ok(response);
    }
    [HttpGet("[action]/{companyid}")]
    public async Task<IActionResult> GetSelectList(string companyid)
    {
        GetSelectListAsyncQuery request = new(companyid);
        GetSelectListAsyncQueryResponse response = await _mediator.Send(request);
        return Ok(response);
    }

}
