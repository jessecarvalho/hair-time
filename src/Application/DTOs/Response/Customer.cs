namespace Application.DTOs;

public record CustomerResponseDTO
{
    public int Id { get; init; }
    public int BarberShopId { get; init; }
    public string Name { get; init; }
    public string Email { get; init; }
    public string Telephone { get; init; }
}