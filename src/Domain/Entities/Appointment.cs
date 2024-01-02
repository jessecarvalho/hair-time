namespace Domain.Entities;

public record Appointment
{
    public int Id { get; init; }
    public int BarberShopId { get; init; }
    public BarberShop BarberShop { get; init; }
    public int CustomerId { get; init; }
    public Customer Customer { get; init; }
    public int ServiceId { get; init; }
    public Service Service { get; init; }
    public DateTime Date { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; init; }
    public int Status { get; init; }
}