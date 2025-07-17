using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ProjectClientHub.Communication.Responses;
using ProjectClientHub.Exceptions.ExceptionsBase;

namespace ProjectClientHub.API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if(context.Exception is ProjectClientHubException projectClientHubException)
            {
                context.HttpContext.Response.StatusCode = (int)projectClientHubException.GetHttpStatusCode();
                context.Result = new ObjectResult(new ResponseErrorMessageJson(projectClientHubException.GetErros()));
            }
            else
            {
                ThrowUnknowError(context);
            }
        }
    
        private void ThrowUnknowError(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new ObjectResult(new ResponseErrorMessageJson("ERRO DESCONHECIDO"));
        }
    }

}
