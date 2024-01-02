namespace Domain.Entities;

public record Service
{
    public int Id { get; init; }
    public int BarberShopId { get; init; }
    public BarberShop BarberShop { get; init; }
    public string Category { get; init; }
    public string Name { get; init; }
    public int Time { get; init; }
    public decimal Value { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; init; }
    public int Status { get; init; }
    public ICollection<Appointment> Appointments { get; set; }
};