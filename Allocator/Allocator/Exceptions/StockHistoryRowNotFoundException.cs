namespace Allocator.API.Exceptions;

public sealed class StockHistoryRowNotFoundException : HttpResponseException
{
    public StockHistoryRowNotFoundException() : 
        base(StatusCodes.Status404NotFound, "Stock history row not found") { }
}
