namespace ProjectClientHub.Exceptions.ExceptionsBase
{
    public abstract class ProjectClientHubException : SystemException
    {
        public ProjectClientHubException(String errorMessage) : base(errorMessage)
        {
            
        }

        public abstract List<string> GetErros();
    }
}
