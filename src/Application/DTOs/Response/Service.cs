namespace Application.DTOs.Response;

public record ServiceResponseDTO
{
    public int Id { get; init; }
    public int BarberShopId { get; init; }
    public string Category { get; init; }
    public string Name { get; init; }
    public int Time { get; init; }
    public decimal Value { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; init; }
    public int Status { get; init; }
}