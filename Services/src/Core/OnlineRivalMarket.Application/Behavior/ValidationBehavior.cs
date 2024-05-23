namespace OnlineRivalMarket.Application.Behavior;
public sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, Result<TResponse>> where TRequest : class, ICommand<Result<TResponse>>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;
    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }
    public async Task<Result<TResponse>> Handle(TRequest request, RequestHandlerDelegate<Result<TResponse>> next, CancellationToken cancellationToken)
    {
        if (!_validators.Any())
            return await next();

        var context = new ValidationContext<TRequest>(request);
        var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
        var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

        if (failures.Count != 0)
            return Result<TResponse>.Failure(failures.Select(f => f.ErrorMessage).ToList());

        return await next();
    }
}
