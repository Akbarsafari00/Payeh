using System;
using System.Net;

namespace Payeh.ApplicationService.Exeptions
{
    public class ApplicationException : Exception
    {
        public string Error { get; set; }
        public object Parameters { get; set; }
        public HttpStatusCode Status { get; set; }

        public ApplicationException(HttpStatusCode status,string error,string? message,  object parameters = null) : base(message)
        {
            Error = error;
            Status = status;
            Parameters = parameters;
        }
    }
}