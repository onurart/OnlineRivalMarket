using FluentValidation;
using FluentValidation.Results;
using MediatR;
using OnlineRivalMarket.Application.Messaging;
using OnlineRivalMarket.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRivalMarket.Application.Behavior
{
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
    //public sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : class, ICommand<TResponse>
    //{
    //    private readonly IEnumerable<IValidator<TRequest>> _validators;
    //    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    //    {
    //        _validators = validators;
    //    }
    //    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    //    {
    //        if (!_validators.Any())
    //        {
    //            return await next();
    //        }
    //        var context = new ValidationContext<TRequest>(request);
    //        var errorDictionary = _validators
    //            .Select(x => x.Validate(context))
    //            .SelectMany(x => x.Errors)
    //            .Where(x => x != null)
    //            .GroupBy(
    //            x => x.PropertyName,
    //            x => x.ErrorMessage, (propertyName, errorMessage) => new
    //            {
    //                Key = propertyName,
    //                Values = errorMessage.Distinct().ToArray()
    //            })
    //            .ToDictionary(x => x.Key, x => x.Values[0]);
    //        if (errorDictionary.Any())
    //        {
    //            var errors = errorDictionary.Select(s => new ValidationFailure
    //            {
    //                PropertyName = s.Value,
    //                ErrorCode = s.Key
    //            });
    //            throw new ValidationException(errors);
    //        }
    //        return await next();
    //    }
    //}
}
