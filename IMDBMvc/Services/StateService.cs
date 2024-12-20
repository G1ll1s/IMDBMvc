using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace IMDBMvc.Services
{
    public class StateService(IHttpContextAccessor contextAccessor, ITempDataDictionaryFactory tempFactory)
    {
        public string? Message
        {
            get
            {
                var tempDataValue = tempFactory.GetTempData(contextAccessor.HttpContext)["Message"];

                return (string)tempDataValue!;
            }
            set
            {
                tempFactory.GetTempData(contextAccessor.HttpContext)["Message"] = value;
            }
        }
    }
}
