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

public class UserGroups
{
    public string Role { get; set; } = string.Empty;
    public int Count { get; set; }
    public List<User> Users { get; set; } = [];
}

public class DbUserGroups
{
    public string Role { get; set; } = string.Empty;
    public int Count { get; set; }
    public string Users { get; set; } = string.Empty;
}