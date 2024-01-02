namespace Domain.Entities;

public record Review
{
    public int Id { get; init; }
    public int BarberShopId { get; init; }
    public BarberShop BarberShop { get; init; }
    public int CustomerId { get; init; }
    public Customer Customer { get; init; }
    public int Rating { get; init; }
    public int CleanlinessRating { get; init; }
    public int ServiceRating { get; init; }
    public int TalkRating { get; init; }
    public int CostRating { get; init; }
    public DateTime CreatedAt { get; init; }
    public int Status { get; init; }
}