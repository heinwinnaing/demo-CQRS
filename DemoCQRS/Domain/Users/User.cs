namespace DemoCQRS.Domain.Users;

public class User
    : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? Phone { get; set; }
    public UserStatus Status { get; set; } = UserStatus.Active;

    public User(string name, string email, string? phone = null)
    {
        Name = name;
        Email = email;
        Phone = phone;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTimeOffset.Now;
        Status = UserStatus.Active;
    }
}
