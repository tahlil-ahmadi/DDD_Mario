using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Framework.Core;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ServiceHost.Filters
{
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var status = HttpStatusCode.InternalServerError;
            var message = "unknown error, please contact support";
            long code = -999;

            if (context.Exception is BusinessException)
            {
                //TODO: log exception
                status = HttpStatusCode.BadRequest;
                message = context.Exception.Message;
                code = ((BusinessException) context.Exception).Code;
            }
         
            context.ExceptionHandled = true;
            HttpResponse response = context.HttpContext.Response;
            response.StatusCode = (int)status;
            response.ContentType = "application/json";
            context.Result = new ObjectResult(new { Message = message, Code =  code});
        }
    }
}
