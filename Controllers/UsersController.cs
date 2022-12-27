using AspApi.Controllers;
using AspApi.Database;
using AspApi.Dto;
using AspApi.Dto.Users;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.EntityFrameworkCore;

namespace ODataCodegen.Controllers;

public class UsersController : DefaultRepositoryController<User,Guid>
{
    public UsersController(SqliteDb sqliteDb) : base(sqliteDb,sqliteDb.Users) { }

    [EnableQuery]
    public IQueryable<User> Get() =>
        DefaultGet();
    
    [EnableQuery]
    public SingleResult<User> Get(Guid key) =>
        DefaultGet(key);

    [EnableQuery]   
    public async Task<IActionResult> PostAsync([FromBody] UserPostDto postDto) =>
        await DefaultPostAsync(postDto);

    [EnableQuery]   
    public async Task<IActionResult> PatchAsync(Guid key,[FromBody] UserPatchDto postDto) =>
        await DefaultPatchAsync(key,postDto);

    [EnableQuery]   
    public async Task<IActionResult> DeleteAsync(Guid key) =>
        await DefaultDeleteAsync(key);
}

