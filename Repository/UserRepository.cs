using DataAccess.Intefaces;
using Models;

namespace Repository;

public class UserRepository (IPostgresContext postgresContext)
{
    public async Task<List<User>> GetUsers() => await postgresContext.Select<User>(Scripts.Scripts.GetUsers);
}