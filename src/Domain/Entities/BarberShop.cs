namespace Infrastructure.Domain.Entities;

public record BarberShop
{
    public int Id { get; init; }
    public string Name { get; init; }
    public string Address { get; init; }
    public string Logo { get; init; }
    public string Whatsapp { get; init; }
    public string Facebook { get; init; }
    public string Instagram { get; init; }
    public string Plan { get; init; }
    public string Email { get; init; }
    public string Password { get; init; }
    public string Salt { get; init; }
    public string Token { get; init; }
    public string TokenExpiration { get; init; }
    public int Status { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; init; }
    public ICollection<Appointment> Appointments { get; set; }
    public ICollection<Service> Services { get; set; }
    public ICollection<ServiceCategory> ServiceCategories { get; set; }
    public ICollection<Review> Reviews { get; set; }
}