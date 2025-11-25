namespace Application.Features.Identity.Users;

public class ChangeUserStatusRequest
{
    public string UserId { get; set; } = string.Empty;
    public bool Activation { get; set; }
}