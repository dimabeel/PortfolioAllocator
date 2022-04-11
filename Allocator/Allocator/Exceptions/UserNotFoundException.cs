namespace Allocator.API.Exceptions;

public sealed class UserNotFoundException : HttpResponseException
{
    public UserNotFoundException() :
        base(StatusCodes.Status404NotFound, "Validation exception.", "User not found.") { }
}
