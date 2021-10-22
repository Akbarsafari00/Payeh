using System.Net;

namespace Payeh.Core.Models
{
    public class ErrorResponseModel
    {
        public HttpStatusCode Status { get; set; }
        public string ErrorContext { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public object Parameters { get; set; }
    }
}