using System.Net;

namespace SimCycle.Model
{
    public class APIResponse<T>
    {
        public bool Succeeded { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
