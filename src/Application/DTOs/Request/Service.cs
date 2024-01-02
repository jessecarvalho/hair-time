namespace Application.DTOs;

public record ServiceRequestDTO
{
    public int BarberShopId { get; set; }
    public string Category { get; set; }
    public string Name { get; set; }
    public int Time { get; set; }
    public decimal Value { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int Status { get; set; }
}