namespace f1_predictions.Core
{
    public class ErrorResponse
    {
       public string message { get; set; }

        public ErrorResponse(string message)
        {
           this.message = message;
        }
    }
}
