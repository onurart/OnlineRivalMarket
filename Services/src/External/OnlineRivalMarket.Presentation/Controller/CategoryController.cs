namespace OnlineRivalMarket.Presentation.Controller;
public class CategoryController : ApiController
{
    public CategoryController(IMediator mediator) : base(mediator){}
    [HttpPost("[action]")]
    public async Task<IActionResult> CreateCategory(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        CreateCategoryCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
    [HttpGet("[action]/{companyid}")]
    public async Task<IActionResult> GetAllCategory(string companyid)
    {
        GetAllCategoryQuery request = new(companyid);
        GetAllCategoryQueryResponse response = await _mediator.Send(request);
        return Ok(response);
    }
}
