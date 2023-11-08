using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Project_Mvc.Filters
{
    public class HandelErrorAttribute : Attribute,IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
          ContentResult result = new ContentResult();
            result.Content=context.Exception.Message;
            context.Result = result;
        }
    }
}
