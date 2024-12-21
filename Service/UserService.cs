using Models;
using Repository.Interfaces;
using Service.Interfaces;

namespace Service;

public class UserService(IUserRepository userRepository) : IUserService
{
    private const string Admin = "admin";
    private const string Shop = "shop";
    private const string Factory = "factory";
    
    private readonly Dictionary<string, int> _roleComparer = new()
    {
        { Admin, 1 },
        { Shop, 2 },
        { Factory, 3 }
    };

    public async Task<List<User>> GetUsers() => (await userRepository.GetUsers()).OrderBy(u => u.Id).ToList();

    public async Task<bool> AddUser(User user)
    {
        user.ClientId = await userRepository.AddClient(user);
        return await userRepository.AddUser(user, _roleComparer[user.Role]);
    }
    
    public async Task<bool> UpdateUser(int id, string status) => await userRepository.UpdateUser(id, status);
    
    public async Task<List<UserGroups>> GetUserGroups() => await userRepository.GetUserGroups();
}
