namespace Allocator.API.Exceptions;

public sealed class AccountNotFoundException : HttpResponseException
{
    public AccountNotFoundException() : base(StatusCodes.Status404NotFound, "Account not found") { }
}
