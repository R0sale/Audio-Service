using System.Text.Json;

namespace AudioService.Api.Middlewares
{
    public class ExceptionHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (Exception ex)
            {
                var error = ex switch
                {
                    OperationCanceledException => (StatusCodes.Status404NotFound, "A timeout has been triggered"),
                    _ => (StatusCodes.Status500InternalServerError, "A server error occured while processing a request")
                };

                await context.Response.WriteAsync(JsonSerializer.Serialize(new
                {
                    message = error.Item2,
                    statusCode = error.Item1
                }));
            }
        }
    }
}
