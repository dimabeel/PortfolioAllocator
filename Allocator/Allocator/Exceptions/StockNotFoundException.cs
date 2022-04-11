namespace Allocator.API.Exceptions;

public sealed class StockNotFoundException : HttpResponseException
{
    public StockNotFoundException() :
        base(StatusCodes.Status404NotFound, "Validation exception.", "Stock not found.") { }
}
