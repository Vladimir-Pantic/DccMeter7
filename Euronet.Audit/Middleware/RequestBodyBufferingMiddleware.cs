using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euronet.Audit.Middleware
{

	public class RequestBodyBufferingMiddleware
	{
		private readonly RequestDelegate _next;

		public RequestBodyBufferingMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			context.Request.EnableBuffering();
			await _next(context);
		}
	}
}
