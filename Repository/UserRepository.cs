using DataAccess.Intefaces;
using Models;
using Repository.Interfaces;

namespace Repository;

public class UserRepository(IPostgresContext postgresContext) : IUserRepository
{
    public async Task<List<User>> GetUsers() => await postgresContext.Select<User>(Scripts.Scripts.GetUsers);

    public async Task<bool> AddUser(User user, int roleId) => await postgresContext.Exec(Scripts.Scripts.AddUser, new
    {
        username = user.Username,
        password = user.Password,
        status = user.Status.ToString(),
        role_id = roleId,
        client_id = user.ClientId,
    });

    public async Task<bool> UpdateUser(int id, string status) => await postgresContext.Exec(Scripts.Scripts.UpdateUser, new
    { 
        status, id
    });

    public async Task<int> AddClient(User user) => await postgresContext.Get<int>(Scripts.Scripts.AddClient, new
    {
        name = user.Name,
        address = user.Address,
        inn = user.INN
    });
}