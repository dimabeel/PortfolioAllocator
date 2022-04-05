using System.Text.Json;

namespace Allocator.API.Exceptions;

public class ErrorDetails
{
    public int StatusCode { get; set; }
    public object? Message { get; set; } = string.Empty;

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}
