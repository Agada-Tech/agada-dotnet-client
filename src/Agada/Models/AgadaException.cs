using System;
using System.Net;

namespace Agada.Models
{
    public class AgadaException : Exception
    {
        public AgadaException( HttpStatusCode statusCode, string message)
        {
            AgadaMessage = message;
            StatusCode = statusCode;
        }
        public string AgadaMessage { get; set; } 
        public HttpStatusCode StatusCode { get; set; } 
    }
}