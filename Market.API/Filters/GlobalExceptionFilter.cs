using Market.Common.Contract;
using Market.Common.Exceptions;
using Market.Common.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace Market.API.Filters
{
    public class GlobalExceptionFilter : ExceptionFilterAttribute
    {
        private ILogger _logger;
        public GlobalExceptionFilter(ILogger logger)
        {
            _logger = logger;
        }
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {

            string exceptionMessage = string.Empty;
            HttpStatusCode httpStatusCode = new HttpStatusCode();
            if (actionExecutedContext.Exception is EntityNotValidException)
            {
                httpStatusCode = HttpStatusCode.NotFound;
                exceptionMessage = actionExecutedContext.Exception.Message;
                _logger.LogError(exceptionMessage);
            }
            if (actionExecutedContext.Exception is UnauthorizedAccessException)
            {
                httpStatusCode = HttpStatusCode.Unauthorized;
                exceptionMessage = actionExecutedContext.Exception.Message;
                _logger.LogError(exceptionMessage);
            }
            if (actionExecutedContext.Exception is NotFoundByIdException)
            {
                httpStatusCode = HttpStatusCode.NotFound;
                exceptionMessage = actionExecutedContext.Exception.Message;
                _logger.LogError(exceptionMessage);
            }
            else
            {
                httpStatusCode = HttpStatusCode.InternalServerError;
                exceptionMessage = actionExecutedContext.Exception.Message;
                _logger.LogError(exceptionMessage);
            }

            var response = new HttpResponseMessage(httpStatusCode)
            {
                Content = new StringContent("An unhandled exception was thrown by service."),
                ReasonPhrase = "Internal Server Error.Please Contact your Administrator."
            };

            actionExecutedContext.Response = response;
        }
    }
}