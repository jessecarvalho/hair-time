namespace Infrastructure.Persistence.DTOs;

public record CustomerDTO
{
    public int Id { get; set; }
    public int BarberShopId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Telephone { get; set; }
}