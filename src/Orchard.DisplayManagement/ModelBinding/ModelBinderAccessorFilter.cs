﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace Orchard.DisplayManagement.ModelBinding
{
    public class ModelBinderAccessorFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var controller = context.Controller as Controller;
            if (controller != null)
            {
                var modelBinderAccessor = context.HttpContext.RequestServices.GetRequiredService<IModelUpdaterAccessor>();
                modelBinderAccessor.ModelUpdater = new ControllerModelUpdater(controller);
            }
        }
    }
}
