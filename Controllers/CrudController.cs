using AspApi.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspApi.Controllers;

/// <summary>
/// Api для локальной sqlite базы данных
/// </summary>
[ApiController]
[Route("rest")]
public class DbController : Controller
{
    private readonly SqliteDb _sqliteDb;

    public DbController(SqliteDb sqliteDb)
    {
        _sqliteDb = sqliteDb;
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetAsync(int id)
    {
        var user = await _sqliteDb.Users.FindAsync(id);
        return user is not null ? Ok(user) : NotFound("Пользователь не найден");
    }


    [HttpPut()]
    public async Task<ActionResult<User>> UpdateAsync([FromBody] User value)
    {
        if(await _sqliteDb.Users.AnyAsync(u => u.Id == value.Id))
        {
            _sqliteDb.Users.Update(value);
            await _sqliteDb.SaveChangesAsync();
            return Ok(value);
        }
        return NotFound("Пользователь не найден");
    }

    [HttpPost()]
    public async Task<ActionResult<User>> PostAsync([FromBody] User value)
    {
        if(await _sqliteDb.Users.AnyAsync(u => u.Id == value.Id))
            return BadRequest($"Пользователь с {value.Id} уже существует");
        await _sqliteDb.Users.AddAsync(value);
        await _sqliteDb.SaveChangesAsync();
        return value;
    }

    [HttpDelete()]
    public async Task<ActionResult<User>> DeleteAsync(int id)
    {
        var user = await _sqliteDb.Users.FindAsync(id);
        if(user is not null)
        {
            _sqliteDb.Users.Remove(user);
            await _sqliteDb.SaveChangesAsync();
            return user;
        }
        return NotFound("Пользователь не найден");
    }
}
