using Models;

namespace Repository.Interfaces;

public interface IUserRepository
{
    Task<List<User>> GetUsers();
    Task<bool> AddUser(User user, int roleId);
    Task<bool> UpdateUser(int id, string status);
    Task<int> AddClient(User user);
    Task<User> GetUserById(int id);
    Task<List<UserGroups>> GetUserGroups();
}