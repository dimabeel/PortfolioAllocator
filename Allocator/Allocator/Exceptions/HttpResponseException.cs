namespace Allocator.API.Exceptions;

public abstract class HttpResponseException : Exception
{
    protected HttpResponseException(int statusCode, object? value = null) =>
        (StatusCode, Value) = (statusCode, value);

    public int StatusCode { get; }

    public object? Value { get; }
}
