namespace Infrastructure.Persistence.Models;

public record Customer
{
    public int Id { get; init; }
    public int BarberShopId { get; init; }
    public BarberShop BarberShop { get; init; }
    public string Name { get; init; }
    public string Email { get; init; }
    public string Password { get; init; }
    public string Telephone { get; init; }
}