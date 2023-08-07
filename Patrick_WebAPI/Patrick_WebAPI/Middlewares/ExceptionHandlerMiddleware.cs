using System.Net;
using Microsoft.Extensions.Logging;

namespace Patrick_WebAPI.Middlewares
{
	public class ExceptionHandlerMiddleware
	{
		private readonly ILogger<ExceptionHandlerMiddleware> logger;
		private readonly RequestDelegate next;

		public ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> logger , RequestDelegate next)
		{
			this.logger = logger;
			this.next = next;
		}

		public async Task InvokeAsync(HttpContext httpContext)
		{
			try
			{
				await next(httpContext);
			}
			catch (Exception ex)
			{

				var errorId = Guid.NewGuid();
				//Log This Exception

				logger.LogError(ex,$"{errorId} : {ex.Message}" );

				httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

				httpContext.Response.ContentType= "application/json";

				var error = new
				{
					Id = errorId,
					ErrorMessage = "Something Went Wrong We are looking to resolve this."
				};

				await httpContext.Response.WriteAsJsonAsync(error);
			}
		}
	}
}
