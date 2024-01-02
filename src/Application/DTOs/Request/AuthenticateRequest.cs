namespace Application.DTOs;

public record AuthenticateRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
}