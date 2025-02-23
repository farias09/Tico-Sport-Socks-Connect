using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using System.Diagnostics;

namespace UI.App_Start
{
    public class GlobalExceptionHandler : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            // Log the exception (you can replace this with your logging framework)
            Trace.TraceError(context.Exception.ToString());

            // Create a response with the exception details
            context.Response = context.Request.CreateResponse(HttpStatusCode.InternalServerError, new
            {
                Message = "An internal error occurred. Please try again later.",
                ExceptionMessage = context.Exception.Message,
                StackTrace = context.Exception.StackTrace
            });
        }
    }
}