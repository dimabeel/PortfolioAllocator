namespace Allocator.API.Exceptions;

public sealed class StockHistoryRowNotFoundException : HttpResponseException
{
    public StockHistoryRowNotFoundException() : 
        base(StatusCodes.Status404NotFound, "StockHistoryRowNotFoundException not found") { }
}
