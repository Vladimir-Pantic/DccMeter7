using System;

namespace Microsoft.AspNetCore.Mvc.Controllers
{
	public static class ControllerActionDescriptorExtensions
	{
		public static string GetActionName(this ControllerActionDescriptor action)
		{
			if (action == null)
			{
				return String.Empty;
			}

			string actionName = actionName = $"{action.ControllerName}.{action.ActionName}";
			

			return actionName;
		}
	}
}
