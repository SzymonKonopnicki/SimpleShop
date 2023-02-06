
namespace SimpleShopApi.Middlewares
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
		private readonly ILogger<ErrorHandlingMiddleware> _logger;
		public ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger)
		{
			_logger = logger;
		}
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
			try
			{
				await next.Invoke(context);
			}
			catch (NotFoundException ex)
			{
				_logger.LogInformation(ex.Message);
				context.Response.StatusCode = 404;
				await context.Response.WriteAsync("Not found.\nTry again with different arguments");
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("Something went wrong.\nTry again later.");
            }
        }
    }
}
