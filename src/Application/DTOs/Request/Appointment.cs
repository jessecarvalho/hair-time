namespace Application.DTOs;

public record AppointmentRequestDTO
{
    public int BarberShopId { get; set; }
    public int ClientId { get; set; }
    public int ServiceId { get; set; }
    public DateTime Date { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int Status { get; set; }
}
