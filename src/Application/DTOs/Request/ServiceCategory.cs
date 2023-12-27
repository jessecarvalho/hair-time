namespace Infrastructure.Persistence.DTOs;

public record ServiceCategoryRequestDTO
{
    public int Id { get; set; }
    public int BarberShopId { get; set; }
    public string Name { get; set; }
    public string Icon { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int Status { get; set; }
}