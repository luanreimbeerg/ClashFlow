namespace ClashFlow.Communication.Response
{
    public class ResponseError
    {
        public string ErrrorMessage { get; set; } = string.Empty;

       
        public ResponseError(string ErrorMessage)
        {
            ErrrorMessage = ErrorMessage;
        }
    }
}
