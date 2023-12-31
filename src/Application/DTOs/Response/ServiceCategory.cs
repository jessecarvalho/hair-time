namespace Application.DTOs;

public record ServiceCategoryResponseDTO
{
    public int Id { get; init; }
    public int BarberShopId { get; init; }
    public string Name { get; init; }
    public string Icon { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; init; }
    public int Status { get; init; }
}