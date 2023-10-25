namespace webapi.Core
{
    public class Response
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public string ErrorMessage { get; set; }
    }

}
