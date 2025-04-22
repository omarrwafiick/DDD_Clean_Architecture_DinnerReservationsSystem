
using FluentResults; 

namespace ApplicationLayer.Common.Errors
{
    public class DuplicateEmailError : IError
    {
        public List<IError> Reasons  {get; set; }

        public string Message { get; set; }

        public Dictionary<string, object> Metadata => throw new NotImplementedException();
    }
}
