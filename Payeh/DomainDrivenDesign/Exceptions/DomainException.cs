using System;

namespace Payeh.DomainDrivenDesign.Exceptions
{
    public class DomainException : Exception
    {
        public string Error { get; set; }
        public object Parameters { get; set; }

        public DomainException(string error,string? message, object parameters = null) : base(message)
        {
            Error = error;
            Parameters = parameters;
        }
    }
}