using System.Net;

namespace Domain.Wrapper;

public class Response<T>
{
    public T Data { get; set; }
    public string Message { get; set; }
    public int StatusCode { get; set; }

    public Response(T data)
    {
        StatusCode = 200;
        Data = data;
    }
    public Response(HttpStatusCode statusCode, string message)
    {
        StatusCode = (int)statusCode;
        Message = message;
    }
    
}