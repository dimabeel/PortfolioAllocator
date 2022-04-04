namespace Allocator.API.Exceptions;

public class UserNotFoundException : HttpResponseException
{
    public UserNotFoundException() : base(404, "User not found") { }
}
