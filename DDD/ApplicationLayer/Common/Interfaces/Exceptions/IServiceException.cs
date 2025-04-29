
using System.Net;

namespace ApplicationLayer.Common.Interfaces.Exceptions
{
    public interface IServiceException
    {
        public HttpStatusCode StatusCode {  get; }
        public string Message { get; set;}
    }
}
