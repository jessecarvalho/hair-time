using Domain.Interfaces;

namespace Domain.Entities;

public record Customer : IUser
{
    public int Id { get; init; }
    public int BarberShopId { get; init; }
    public BarberShop BarberShop { get; init; }
    public string Name { get; init; }
    public string Email { get; init; }
    public string Password { get; init; }
    public string Telephone { get; init; }
    public ICollection<Appointment> Appointments { get; set; }
    public ICollection<Review> Reviews { get; set; }
}