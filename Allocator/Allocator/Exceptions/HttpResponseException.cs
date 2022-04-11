namespace Allocator.API.Exceptions;

public class HttpResponseException : Exception
{
    public HttpResponseException(int statusCode, string title, object? value = null)
    {
        StatusCode = statusCode;
        Value = value;
        Title = title;
    }

    public string Title { get; }

    public int StatusCode { get; }

    public object? Value { get; }
}
