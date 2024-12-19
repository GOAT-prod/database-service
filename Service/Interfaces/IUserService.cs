using Models;

namespace Service.Interfaces;

public interface IUserService
{
    Task<List<User>> GetUsers();
    Task<bool> AddUser(User user);
    Task<bool> UpdateUser(int id, string status);
}