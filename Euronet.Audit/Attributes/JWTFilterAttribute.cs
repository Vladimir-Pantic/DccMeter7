using Euronet.Audit.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euronet.Audit
{
	public class JWTFilterAttribute : IAuthorizationFilter
	{
		protected IAuditLog AuditLog { get; set; }

		public JWTFilterAttribute(IAuditLog auditLog)
		{
			AuditLog = auditLog;
		}
		
		public void OnAuthorization(AuthorizationFilterContext context)
		{
			var controller = context.ActionDescriptor as ControllerActionDescriptor;
			if (controller != null)
			{
				var actionAttributes = controller.MethodInfo.GetCustomAttributes(true);

				var controllerAttributes = controller.ControllerTypeInfo.GetCustomAttributes(true);

				var allAttributes = actionAttributes.Concat(controllerAttributes);

				if (/*!allAttributes.OfType<AllowAnonymousAttribute>().Any() ||*/ allAttributes.OfType<AuthorizeAttribute>().Any())
				{
					if (!context.HttpContext.User.Identity.IsAuthenticated)
					{
						context.HttpContext.Request.EnableBuffering();

						// Read the request body
						using (var reader = new StreamReader(context.HttpContext.Request.Body, Encoding.UTF8, leaveOpen: true))
						{
							context.HttpContext.Request.Body.Position = 0;
							var body = reader.ReadToEndAsync().Result;

							context.AuthorizationAudit(AuditLog, 0, "", DateTime.Now, DateTime.Now, new Exception("Not authorized!"), body, 401); // sredi body
							context.HttpContext.Request.Body.Position = 0;
						}
						
					}
				}
			}
			
		}
	}
}
