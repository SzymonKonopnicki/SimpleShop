
namespace SimpleShopApi.Middlewares
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
			try
			{
				await next.Invoke(context);
			}
			catch (NotFoundException ex)
			{
				context.Response.StatusCode = 404;
				await context.Response.WriteAsync("Not found.\nTry again with different arguments");
				Console.WriteLine("Stack trace:\n" + ex.StackTrace + "End stack trace.");
			}
			catch (Exception)
			{
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("Not rdy.\nTry again later.");
            }
        }
    }
}
