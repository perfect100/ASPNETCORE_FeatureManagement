using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.Mvc;

namespace ASPNETCore.FeatureManagement.Controllers
{
    [FeatureGate(nameof(FeatureNames.FeatureA))]
    [Route("[controller]")]
    public class Demo2Controller : ControllerBase
    {
        /// <summary>
        /// Please change the app settings of FeatureA when running.
        /// </summary>
        /// <param name="featureManager"></param>
        /// <returns></returns>
        [HttpGet("di")]
        public async Task<string> GetResultWithDi([FromServices] IFeatureManager featureManager)
        {
            const string functionName = nameof(FeatureNames.FeatureA);
            var functionState = await featureManager.IsEnabledAsync(functionName);
            return $"{functionName} is {(functionState ? "On" : "Off")}";
        }

        /// <summary>
        /// Please change the app settings of FeatureA when running.
        /// </summary>
        /// <returns></returns>
        [FeatureGate(nameof(FeatureNames.FeatureA))]
        [HttpGet("attrSingle")]
        public string GetResultWithAttributeAndSingleFeature()
        {
            // If the FeatureA is off, it can not get here.
            return $"{nameof(FeatureNames.FeatureA)} is On";
        }
        
        /// <summary>
        /// Please change the app settings of FeatureA and FeatureB when running.
        /// </summary>
        /// <returns></returns>
        [FeatureGate(RequirementType.All, nameof(FeatureNames.FeatureA), nameof(FeatureNames.FeatureB))]
        [HttpGet("attrMultiAll")]
        public string GetResultWithAttributeAndMultiFeaturesAll()
        {
            // If the FeatureA is off, it can not get here.
            return $"{nameof(FeatureNames.FeatureA)} and {nameof(FeatureNames.FeatureB)} are both On";
        }
        
        /// <summary>
        /// Please change the app settings of FeatureA and FeatureB when running.
        /// </summary>
        /// <returns></returns>
        [FeatureGate(RequirementType.Any, nameof(FeatureNames.FeatureA), nameof(FeatureNames.FeatureB))]
        [HttpGet("attrMultiAny")]
        public string GetResultWithAttributeAndMultiFeaturesAny()
        {
            // If the FeatureA is off, it can not get here.
            return $"{nameof(FeatureNames.FeatureA)} or {nameof(FeatureNames.FeatureB)} is On";
        }
    }
}