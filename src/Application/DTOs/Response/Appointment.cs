namespace Application.DTOs.Response;

public record AppointmentResponseDTO
{
    public int Id { get; init; }
    public int BarberShopId { get; init; }
    public int ServiceId { get; init; }
    public int UserId { get; init; }
    public DateTime Date { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; init; }
    public int Status { get; init; }
}