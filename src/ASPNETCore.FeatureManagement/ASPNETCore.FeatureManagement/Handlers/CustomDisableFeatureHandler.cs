using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.FeatureManagement.Mvc;

namespace ASPNETCore.FeatureManagement.Handlers
{
    public class CustomDisableFeatureHandler : IDisabledFeaturesHandler
    {
        public Task HandleDisabledFeatures(IEnumerable<string> features, ActionExecutingContext context)
        {
            context.Result = new JsonResult(new
            {
                Error = true,
                Message = "Feature(s) is off, please try again later.",
                Features = features,
            });
            
            return Task.CompletedTask;
        }
    }
}