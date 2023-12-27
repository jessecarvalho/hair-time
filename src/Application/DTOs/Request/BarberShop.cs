namespace Infrastructure.Persistence.DTOs;

public record BarberShopRequestDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Logo { get; set; }
    public string Whatsapp { get; set; }
    public string Facebook { get; set; }
    public string Instagram { get; set; }
    public string Plan { get; set; }
    public string Email { get; set; }
    public int Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}