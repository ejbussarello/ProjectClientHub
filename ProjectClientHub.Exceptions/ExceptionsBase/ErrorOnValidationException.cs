using System.Net;

namespace ProjectClientHub.Exceptions.ExceptionsBase
{
    public class ErrorOnValidationException : ProjectClientHubException
    {
        private readonly List<string> _errors;

        public ErrorOnValidationException(List<String> errorMessages) : base(string.Empty)
        {
            _errors = errorMessages;
        }

        public override List<string> GetErros()
        {
            return _errors;
        }

        public override HttpStatusCode GetHttpStatusCode() => HttpStatusCode.BadRequest;
    }
}
