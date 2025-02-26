
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using Newtonsoft.Json;
using Euronet.Audit.Interfaces;

namespace Microsoft.AspNetCore.Mvc.Filters
{
	public static class ActionExecutedContextExtensions
	{
		public static void Audit(this ActionExecutedContext context, 
			IAuditLog auditLog,
			long resourceId, string resourceName,
			DateTime? requestTime, DateTime responseTime,
			Exception exception, string requestBody, int statusCode)
		{
			FilterContextExtensions.Audit(context, auditLog, resourceId, resourceName, requestTime, responseTime, exception, context?.Result, requestBody, statusCode);
		}

        public static void AuthorizationAudit(this AuthorizationFilterContext context, 
            IAuditLog auditLog,
			long resourceId, string resourceName,
			DateTime? requestTime, DateTime responseTime,
			Exception exception, string requestBody, int statusCode)
        {
			FilterContextExtensions.Audit(context, auditLog, resourceId, resourceName, requestTime, responseTime, exception, context?.Result, requestBody, statusCode);
		}

        public static Exception GetException(this ActionExecutedContext context)
        {
            if (context == null)
            {
                return null;
            }

            ObjectResult objectResult = context.Result as ObjectResult;

            if (objectResult != null && objectResult.IsNotOk())
            {
                return objectResult.Value as Exception;
            }
            else
            {
                return context.Exception;
            }
        }
    }
}
