using System.Text.Json;

namespace Allocator.API.Exceptions;

public class ErrorDetails
{
    public int Status { get; set; }
    public string Title { get; set; } = string.Empty;
    public object? Message { get; set; } = string.Empty;
    public string TraceId { get; set; } = string.Empty;

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}