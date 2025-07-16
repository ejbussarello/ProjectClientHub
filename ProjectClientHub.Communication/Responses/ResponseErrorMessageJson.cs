namespace ProjectClientHub.Communication.Responses
{
    public class ResponseErrorMessageJson
    {
        public List<String> Errors { get; private set; }

        public ResponseErrorMessageJson(String message)
        {
            Errors = [message];
        }
    }
}
