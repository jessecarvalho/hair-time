namespace Infrastructure.Persistence.DTOs;

public record ReviewDTO
{
    public int Id { get; set; }
    public int BarberShopId { get; set; }
    public int ClientId { get; set; }
    public int Rating { get; set; }
    public int CleanlinessRating { get; set; }
    public int ServiceRating { get; set; }
    public int TalkRating { get; set; }
    public int CostRating { get; set; }
    public DateTime CreatedAt { get; set; }
    public int Status { get; set; }
}