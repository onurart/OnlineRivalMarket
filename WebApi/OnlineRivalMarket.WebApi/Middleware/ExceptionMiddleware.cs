using FluentValidation;
using Newtonsoft.Json;
using OnlineRivalMarket.Application.Services;


namespace OnlineRivalMarket.WebApi.Middleware
{
    public sealed class ExceptionMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }

            if (context.Response.StatusCode == 401)
            {
                context.Response.ContentType = "application/json";
                var result = new Result<object>(401, "Unauthorized");
                await context.Response.WriteAsync(JsonConvert.SerializeObject(result));
            }
            else if (context.Response.StatusCode == 402)
            {
                context.Response.ContentType = "application/json";
                var result = new Result<object>(403, "Payment Required");
                await context.Response.WriteAsync(JsonConvert.SerializeObject(result));
            }
            else if (context.Response.StatusCode == 403)
            {
                context.Response.ContentType = "application/json";
                var result = new Result<object>(403, "Forbidden");
                await context.Response.WriteAsync(JsonConvert.SerializeObject(result));
            }
            else if (context.Response.StatusCode == 404)
            {
                context.Response.ContentType = "application/json";
                var result = new Result<object>(403, "Not Found");
                await context.Response.WriteAsync(JsonConvert.SerializeObject(result));
            }
            else if (context.Response.StatusCode == 405)
            {
                context.Response.ContentType = "application/json";
                var result = new Result<object>(403, "Method Not Allowed");
                await context.Response.WriteAsync(JsonConvert.SerializeObject(result));
            }
        }
        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            //context.Response.StatusCode = (int)StatusCodes.Status500InternalServerError;
            if (ex.GetType() == typeof(ValidationException))
            {
                return context.Response.WriteAsync(new ValidationErrorDetails
                {
                    Errors = ((ValidationException)ex).Errors.Select(s => s.PropertyName),
                    StatusCode = context.Response.StatusCode
                }.ToString());
            }

            return context.Response.WriteAsync(new ErrorResult
            {
                Message = ex.Message,
                StatusCode = context.Response.StatusCode
            }.ToString());
        }
    }
}
