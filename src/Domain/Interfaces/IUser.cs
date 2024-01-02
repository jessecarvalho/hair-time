namespace Domain.Interfaces;

public interface IUser
{
    public string Name { get; init; }
    public string Email { get; init; }
    public string Password { get; init; }
    public string Telephone { get; init; }
}