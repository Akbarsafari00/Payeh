using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Payeh.Core.Models;
using Payeh.DomainDrivenDesign.Exceptions;
using ApplicationException = Payeh.ApplicationService.Exeptions.ApplicationException;

namespace Payeh.Utilities.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (System.Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, System.Exception exception)
        {
            
            
            DefaultContractResolver contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };
            HttpStatusCode status;
            var message = exception.Message;
            var errorCode = "Global";

            var exceptionType = exception.GetType().BaseType;
            if (exceptionType == typeof(ApplicationException))
            {
                status = ((ApplicationException) exception).Status;
                errorCode = ((ApplicationException) exception).Error;
                var parameters = ((ApplicationException) exception).Parameters;
                var result = JsonConvert.SerializeObject(new
                    ErrorResponseModel()
                    {
                        ErrorContext = "Application",
                        Status = status,
                        ErrorCode = errorCode,
                        ErrorMessage = message,
                        Parameters = parameters
                    }, new JsonSerializerSettings
                {
                    ContractResolver = contractResolver,
                    Formatting = Formatting.Indented
                });
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int) status;
                return context.Response.WriteAsync(result);
            }
            else if (exceptionType == typeof(DomainException))
            {
                status = HttpStatusCode.InternalServerError;
                errorCode = ((DomainException) exception).Error;
                var parameters = ((DomainException) exception).Parameters;
                var result = JsonConvert.SerializeObject(new
                    ErrorResponseModel()
                    {
                        Status = status,
                        ErrorContext = "Domain",
                        ErrorCode = errorCode,
                        ErrorMessage = message,
                        Parameters = parameters
                    }, new JsonSerializerSettings
                {
                    ContractResolver = contractResolver,
                    Formatting = Formatting.Indented
                });
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int) status;
                return context.Response.WriteAsync(result);
            }
            else
            {
                
                Console.WriteLine(exception.StackTrace);
                var result = JsonConvert.SerializeObject(new
                    ErrorResponseModel {
                        
                    Status = HttpStatusCode.InternalServerError,
                    ErrorContext = "System",
                    ErrorMessage = message,
                    ErrorCode = errorCode,
                }, new JsonSerializerSettings
                {
                    ContractResolver = contractResolver,
                    Formatting = Formatting.Indented
                });
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = 500;
                return context.Response.WriteAsync(result);
            }
        }
    }
}