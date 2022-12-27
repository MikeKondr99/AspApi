using AspApi.Database;
using FluentValidation;
using AspApi.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using FluentValidation.Results;

namespace AspApi.Controllers;


public interface IHasKey<T> 
{
    public T Id { get; set; }
}

public abstract class DefaultRepositoryController<T,TKey> : ODataController  where T : class, IHasKey<TKey>
{
    protected DbSet<T> Table { get; init;}
    protected DbContext Context { get; init;}

    public DefaultRepositoryController(DbContext db,
                                       DbSet<T> table) {
        Context = db;
        Table = table;
    }

    public virtual IQueryable<T> DefaultGet()
    {
        return Table;
    }
    
    public virtual SingleResult<T> DefaultGet(TKey key)
    {
        return SingleResult.Create(Table.Where(u => u.Id!.Equals(key)));
    }

    public virtual async Task<IActionResult> DefaultPostAsync(IPostDto<T> postDto) 
    {
        if(!ModelState.IsValid)
            BadRequest();
        var user = postDto.Create();
        await Table.AddAsync(user);
        await Context.SaveChangesAsync();
        return Created(user);
    }

    public virtual async Task<IActionResult> DefaultPatchAsync(TKey key, IPatchDto<T> patchDto)
    {
        if(!ModelState.IsValid)
            BadRequest();
        var user = await Table.FindAsync(key);
        if(user is null) 
            return NotFound();
        user = patchDto.Patch(user);
        await Context.SaveChangesAsync();
        return Updated(user);
    }

    public virtual async Task<IActionResult> DefaultDeleteAsync(TKey key)
    {
        var user = await Table.FindAsync(key);
        if(user is null) 
            return NotFound();
        Table.Remove(user);
        await Context.SaveChangesAsync();
        return NoContent();
    }
}

