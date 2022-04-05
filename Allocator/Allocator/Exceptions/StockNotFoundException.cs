namespace Allocator.API.Exceptions;

public sealed class StockNotFoundException : HttpResponseException
{
    public StockNotFoundException() : base(StatusCodes.Status404NotFound, "Stock not found") { }
}
