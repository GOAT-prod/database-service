using Microsoft.AspNetCore.Mvc;
using Models;
using Service.Interfaces;

namespace database_service.Controllers;

[ApiController]
public class UserController(IUserService userService) : ControllerBase
{
    [HttpGet("/users")]
    public async Task<List<User>> GetUsers() => await userService.GetUsers();

    [HttpPost("/user")]
    public async Task<IActionResult> AddUser([FromBody] User user) => Ok(await userService.AddUser(user));
    
    [HttpPut("/user/{id}/status/{status}")]
    public async Task<IActionResult> UpdateUser(int id, string status) => Ok(await userService.UpdateUser(id, status));
    
    [HttpGet("/users/groups")]
    public async Task<List<UserGroups>> GetUserGroups() => await userService.GetUserGroups();
}