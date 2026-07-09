namespace ClashFlow.Communication.Response
{
    public class ResponseError
    {
        public List<string> ErrorMessages { get; set; }

       
        public ResponseError(string ErrorMessage)
        {
            ErrorMessages = [ErrorMessage];
        }

        public ResponseError(List<string> errorMessages)
        {
            ErrorMessages = errorMessages;
        }
    }
}
