namespace Models;

public class User 
{
    public int? Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public int ClientId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string INN { get; set; } = string.Empty;
    public UserStatus Status { get; set; }
}